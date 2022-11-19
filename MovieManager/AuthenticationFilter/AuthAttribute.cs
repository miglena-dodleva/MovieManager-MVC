using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieManager.Entities;
using MovieManager.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.AuthenticationFilter
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Session.GetObjectFromJson<User>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Register");

        }
    }
}
