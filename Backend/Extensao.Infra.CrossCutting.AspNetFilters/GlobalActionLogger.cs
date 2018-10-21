﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Elmah.Io.Client;
using Elmah.Io.Client.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Extensao.Infra.CrossCutting.AspNetFilters
{
    public class GlobalActionLogger : IActionFilter
    {
        private readonly ILogger<GlobalActionLogger> _logger;
        private readonly IHostingEnvironment _hostingEnviroment;


        public GlobalActionLogger(ILogger<GlobalActionLogger> logger,
                                             IHostingEnvironment hostingEnviroment)
        {
            _logger = logger;
            _hostingEnviroment = hostingEnviroment;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_hostingEnviroment.IsDevelopment())
            {
                var data = new
                {
                    Version = "v1.0",
                    User = context.HttpContext.User.Identity.Name,
                    IP = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Hostname = context.HttpContext.Request.Host.ToString(),
                    AreaAccessed = context.HttpContext.Request.GetDisplayUrl(),
                    Action = context.ActionDescriptor.DisplayName,
                    TimeStamp = DateTime.Now
                };

                _logger.LogInformation(1, data.ToString());
            }

            if (_hostingEnviroment.IsProduction())
            {
                var message = new CreateMessage
                {
                    Version = "v1.0",
                    Application = "Extesao",
                    Source = "GlobalActionLoggerFilter",
                    User = context.HttpContext.User.Identity.Name,
                    Hostname = context.HttpContext.Request.Host.Host,
                    Url = context.HttpContext.Request.GetDisplayUrl(),
                    DateTime = DateTime.Now,
                    Method = context.HttpContext.Request.Method,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Cookies = context.HttpContext.Request?.Cookies?.Keys.Select(k => new Item(k, context.HttpContext.Request.Cookies[k])).ToList(),
                    Form = Form(context.HttpContext),
                    ServerVariables = context.HttpContext.Request?.Headers?.Keys.Select(k => new Item(k, context.HttpContext.Request.Headers[k])).ToList(),
                    QueryString = context.HttpContext.Request?.Query?.Keys.Select(k => new Item(k, context.HttpContext.Request.Query[k])).ToList(),
                    Data = context.Exception?.ToDataList(),
                    Detail = JsonConvert.SerializeObject(new { DadoExtra = "Dados a mais", DadoInfo = "Pode ser um Json" })
                };


                var client = ElmahioAPI.Create("4a6c1791006e41ffa826a612096a8293");
                //await client.Messages.CreateAndNotifyAsync(new Guid("1669ed24-9c1e-47c5-b776-6588be61c064"), message);
            }
        }


        private static List<Item> Form(HttpContext httpContext)
        {
            try
            {
                return httpContext.Request?.Form?.Keys.Select(k => new Item(k, httpContext.Request.Form[k])).ToList();
            }
            catch (InvalidOperationException)
            {
                // Request not a form POST or similar
            }

            return null;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
