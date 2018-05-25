using System;
using Microsoft.AspNetCore.Http;
using TM.Core.Encrypt;
namespace TM.Core.Cookies {
    //Cookies
    public static class CookiesExtensions {
        public static void Set(this Microsoft.AspNetCore.Http.IResponseCookies cookies, string key, string value, CookieOptions options = null) {
            if (options != null)
                cookies.Append(key, value.Encode(), options);
            else
                cookies.Append(key, value.Encode());
        }
        public static void Set(this Microsoft.AspNetCore.Http.IResponseCookies cookies, string key, string value, int? Expires, bool HttpOnly = true) {
            var options = new CookieOptions();
            if (Expires.HasValue) options.Expires = DateTime.Now.AddMinutes(Expires.Value);
            else options.Expires = DateTime.Now.AddMinutes(1);
            options.HttpOnly = HttpOnly;
            cookies.Append(key, value.Encode(), options);
        }
        public static void Set<T>(this Microsoft.AspNetCore.Http.IResponseCookies cookies, string key, T value, CookieOptions options = null) {
            if (options != null)
                cookies.Append(key, Newtonsoft.Json.JsonConvert.SerializeObject(value).Encode(), options);
            else
                cookies.Append(key, Newtonsoft.Json.JsonConvert.SerializeObject(value).Encode());
        }
        public static void Set<T>(this Microsoft.AspNetCore.Http.IResponseCookies cookies, string key, T value, int? Expires, bool HttpOnly = true) {
            var options = new CookieOptions();
            if (Expires.HasValue) options.Expires = DateTime.Now.AddMinutes(Expires.Value);
            else options.Expires = DateTime.Now.AddMinutes(1);
            options.HttpOnly = HttpOnly;
            cookies.Append(key, Newtonsoft.Json.JsonConvert.SerializeObject(value).Encode(), options);
        }
        public static string Get(this Microsoft.AspNetCore.Http.HttpRequest HttpRequest, string key) {
            var value = HttpRequest.Cookies[key];
            return value == null ? null : value.Decode();
        }
        public static T Get<T>(this Microsoft.AspNetCore.Http.HttpRequest HttpRequest, string key) {
            var value = HttpRequest.Cookies[key];
            return value == null ? default(T) : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value.Decode());
        }
        public static void Remove(this Microsoft.AspNetCore.Http.HttpResponse HttpResponse, string key) {
            HttpResponse.Cookies.Delete(key);
        }
    }
    //Session Extensions
    public static class SessionExtensions {
        public static void Set<T>(this Microsoft.AspNetCore.Http.ISession session, string key, T value) {
            session.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value).Encode());
        }

        public static T Get<T>(this Microsoft.AspNetCore.Http.ISession session, string key) {
            var value = session.GetString(key);
            return value == null ? default(T) : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value.Decode());
        }
    }
}