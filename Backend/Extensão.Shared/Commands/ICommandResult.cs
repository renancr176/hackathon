﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Extensão.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
