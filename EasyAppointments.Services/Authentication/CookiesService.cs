
using Microsoft.AspNetCore.Http;

namespace EasyAppointments.Services.Authentication
{
    public class CookiesService(IHttpContextAccessor contextAccessor)
    {
        public void AppendCookie(string key, string value, DateTime expiryDate)
        {
            CookieOptions options = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = expiryDate,
                SameSite = SameSiteMode.None,
            };
            var context = contextAccessor.HttpContext;
            if (context != null)
            {
                context.Response.Cookies.Append(key, value, options);
            }
        }
        public string GetCookie(string key)
        {
            var value = contextAccessor.HttpContext.Request.Cookies[key];
            return value;
        }
        public void RemoveCookie(string key)
        {
            contextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
        public bool IsCookieExist(string key)
        {
            var value = contextAccessor.HttpContext.Request.Cookies[key];
            return value is null ? false : true;
        }
    }
}
