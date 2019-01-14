using MarvelCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MarvelCore.Controllers
{
    public class BaseController : Controller
    {
        protected User GetUser() {
            var obj = this.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();

            return obj != null ? new User { Id = obj.Value } : null;
        }
    }
}
