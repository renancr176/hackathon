using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Extensao.Domain.Interfaces
{
    public interface IUser
    {
		Guid GetUserId();
		string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
