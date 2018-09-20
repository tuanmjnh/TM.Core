using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace TM.Core {
    //HttpContext
    public static class HttpContext {
        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services {
            get { return services; }
            set {
                if (services != null)
                    throw new Exception("Can't set once a value has already been set.");
                services = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Http {
            get {
                var HttpContextAccessor = services.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor)) as Microsoft.AspNetCore.Http.IHttpContextAccessor;
                return HttpContextAccessor?.HttpContext;
            }
        }
        public static Microsoft.AspNetCore.Mvc.ActionContext Action {
            get {
                var ActionContextAccessor = services.GetService(typeof(Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor)) as Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor;
                return ActionContextAccessor?.ActionContext;
            }
        }
        public static Microsoft.AspNetCore.Hosting.IHostingEnvironment HostingEnvironment {
            get {
                return ((Microsoft.AspNetCore.Hosting.IHostingEnvironment) Http.RequestServices.GetService(typeof(Microsoft.AspNetCore.Hosting.IHostingEnvironment)));
            }
        }
        public static string ContentRootPath {
            get {
                return HostingEnvironment.ContentRootPath;
            }
        }
        public static string WebRootPath {
            get {
                return HostingEnvironment.WebRootPath;
            }
        }
        public static string CurrentController {
            get {
                return Action.RouteData.Values["controller"].ToString();
            }
        }
        public static string CurrentAction {
            get {
                return Action.RouteData.Values["action"].ToString();
            }
        }
        public static string baseUrl {
            get {
                return $"{Http.Request.Scheme}://{Http.Request.Host}{Http.Request.PathBase}";
            }
        }
        public static string Header(string value = "Author", string defaultValues = "Admin") {
            try {
                var rs = Http.Request.Headers[value].ToString();
                return string.IsNullOrEmpty(rs) ? defaultValues : rs;
            } catch { throw; }
        }
        //AppSettings
        public static IConfiguration configuration {
            get {
                var configuration = services.GetService(typeof(IConfiguration)) as IConfiguration;
                return configuration;
            }
        }
    }
}