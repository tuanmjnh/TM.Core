using System.Linq;
namespace TM.Core.Helpers {
    public class Url {
        private static readonly string ContinueUrl = "continue";
        public static string BaseUrl {
            get {
                var rs = string.Format("{0}://{1}",
                    TM.Core.HttpContext.Http.Request.Scheme,
                    TM.Core.HttpContext.Http.Request.Host);
                return rs;
            }
        }
        public static string BasePath {
            get {
                var rs = string.Format("{0}://{1}{2}",
                    TM.Core.HttpContext.Http.Request.Scheme,
                    TM.Core.HttpContext.Http.Request.Host,
                    TM.Core.HttpContext.Http.Request.Path);
                return rs;
            }
        }
        public static string Current {
            get {
                var rs = string.Format("{0}://{1}{2}{3}",
                    TM.Core.HttpContext.Http.Request.Scheme,
                    TM.Core.HttpContext.Http.Request.Host,
                    TM.Core.HttpContext.Http.Request.Path,
                    TM.Core.HttpContext.Http.Request.QueryString);
                return rs;
            }
        }
        public static string Continue {
            get {
                return Current.Replace(BaseUrl, "").Trim('/');
            }
        }
        public static string RedirectContinue() {
            return RedirectContinue(BaseUrl);
        }
        public static string RedirectContinue(string url, bool ajaxRequest = false) {
            var rs = BaseUrl;
            if (ajaxRequest)
                rs = url != null ? $"{rs}/{url.Replace("?continue=", "")}" : rs;
            else
                rs = TM.Core.HttpContext.Http.Request.Query.ContainsKey(ContinueUrl) ? BaseUrl + "/" + TM.Core.HttpContext.Http.Request.Query.Where(d => d.Key == ContinueUrl).FirstOrDefault().Value : BaseUrl;
            return rs;
            // var a = TM.Core.HttpContext.Current.Http.Request.Query.ContainsKey(ContinueUrl);
            // if (a) {
            //     return BaseUrl + "/" + TM.Core.HttpContext.Current.Http.Request.Query.Where(d => d.Key == ContinueUrl).FirstOrDefault().Value;
            // }
            // return BasePath;
        }
        //public static string BaseUrl = GetBaseUrl();
        //public static string GetBaseHost()
        //{
        //    var request = TM.Core.HttpContext.Current.Http.Request;
        //    return request.Url.Scheme + "://" + request.ServerVariables["HTTP_HOST"];
        //}
        //public static string GetBaseUrl()
        //{
        //    //if (HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("//localhost") == -1) return "/";
        //    //else return "/" + HttpContext.Current.Request.Url.AbsolutePath.Split('/')[1] + "/";
        //    //return HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
        //    return (GetBaseHost() + HttpContext.Current.Request.ApplicationPath).Trim('/');
        //}
        //public static string getQueryString()
        //{
        //    return HttpContext.Current.Request.QueryString.ToString();
        //}
        //public static string getQueryString(string QueryString, string ReturnString)
        //{
        //    var q = HttpContext.Current.Request.QueryString;
        //    if (q[QueryString] != null)
        //        return q[QueryString].ToString();
        //    return ReturnString;
        //}
        //public static string getQueryString(string QueryString)
        //{
        //    return getQueryString(QueryString, null);
        //}
        //public static string LastPath()
        //{
        //    string url = HttpContext.Current.Request.Url.AbsolutePath;
        //    url = url.Substring(url.Length - 1, 1) == "/" ? url.Substring(0, url.Length - 1) : url;
        //    return url.Split('/')[url.Split('/').Length - 1];
        //}
        //public static string RedirectLogin(string loginUrl)
        //{
        //    if (HttpContext.Current.Request.QueryString["continue"] == null)
        //        //HttpContext.Current.Response.Redirect(TM.Url.BaseUrl + "/" + loginUrl + "?continue=" + urlEncode(HttpContext.Current.Request.Url.ToString()));
        //        return BaseUrl + "/" + loginUrl + "?continue=" + urlEncode(HttpContext.Current.Request.Url.ToString());
        //    return BaseUrl;
        //}
        //public static string RedirectLogin()
        //{
        //    return RedirectLogin("auth");
        //}
        //public static string RedirectContinue()
        //{
        //    return RedirectContinue(BaseUrl);
        //}
        //public static string RedirectContinue(string url)
        //{
        //    if (HttpContext.Current.Request.QueryString["continue"] != null)
        //    {
        //        string query = HttpContext.Current.Request.Url.Query;
        //        //HttpContext.Current.Response.Redirect(urlDecode(query.Replace("?continue=", "")));
        //        return urlDecode(query.Replace("?continue=", ""));
        //    }
        //    return url; //HttpContext.Current.Response.Redirect(url);
        //}
        //public static string ContinueUrl()
        //{
        //    return System.Web.HttpContext.Current.Request.Url.ToString().Replace(TM.Url.BaseUrl, "").Trim('/');
        //}
    }
}