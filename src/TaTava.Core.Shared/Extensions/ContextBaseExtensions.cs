using System;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace TaTava.Extensions
{
    public static class ContextBaseExtensions
    {
        private static MediaTypeHeaderValue GetContentType(HttpContext context)
        {
            MediaTypeHeaderValue mt;
            MediaTypeHeaderValue.TryParse(context.Request.ContentType, out mt);
            return mt;
        }

        public static T GetService<T>(this HttpContext context)
        {
            return context.RequestServices.GetService<T>();
        }

        public static T GetService<T>(this ViewContext viewContext)
        {
            return viewContext.HttpContext.GetService<T>();
        }

        public static string GetFullHtmlFieldName(this ViewContext viewContext, string name)
        {
            return viewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        }

        public static string GetIp(this HttpContext context)
        {
            return context?.Features?.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
        }

        public static string GetRemoteIp(this HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("X-FORWARDED-FOR", out StringValues values))
            {
                var parsedIp = values.ToString();
                return parsedIp.Split(',').First();
            }

            return context.GetIp();
        }

        public static Uri GetUri(this HttpRequest request)
        {
            if (null == request)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (true == string.IsNullOrWhiteSpace(request.Scheme))
            {
                throw new ArgumentException("Http request Scheme is not specified");
            }

            if (false == request.Host.HasValue)
            {
                throw new ArgumentException("Http request Host is not specified");
            }

            var builder = new StringBuilder();

            builder.Append(request.Scheme)
                .Append("://")
                .Append(request.Host);

            if (true == request.Path.HasValue)
            {
                builder.Append(request.Path.Value);
            }

            if (true == request.QueryString.HasValue)
            {
                builder.Append(request.QueryString);
            }

            return new Uri(builder.ToString());
        }

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";

            return false;
        }

        public static bool IsMultipartFormdataRequest(this HttpContext context)
        {
            var contentType = GetContentType(context);
            return contentType != null && contentType.MediaType.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsMobileDevice(this HttpContext context)
        {
            return context.Request.Headers["User-Agent"].ToString().ToLower().Contains("mobi");
        }

        public static bool IsMobileDevice(this ViewContext context)
        {
            return context.HttpContext.IsMobileDevice();
        }

        public static string GetUserAgent(this HttpRequest request)
        {
            return request.Headers["User-Agent"].ToString();
        }
    }
}