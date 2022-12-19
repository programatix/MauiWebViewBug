using MauiWebViewBug.Control;
using Microsoft.Maui.Handlers;

namespace MauiWebViewBug.Platforms.Android.Handlers
{
    public class MyWebViewHandler : WebViewHandler
    {
        protected override void ConnectHandler(global::Android.Webkit.WebView platformView)
        {
            var url = platformView.Url;
            if (this.VirtualView is MyWebView webview)
            {
                if (string.IsNullOrEmpty(url) && webview.Source is UrlWebViewSource src)
                {
                    url = src.Url;
                }

                // Set HTTP header
                var headers = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(webview.AuthToken))
                {
                    // Add the authorization header
                    headers.Add("Authorization", webview.AuthToken);
                }
                if (!string.IsNullOrEmpty(webview.AcceptLanguage))
                {
                    headers.Add("Accept-Language", webview.AcceptLanguage);
                }
                headers.Add("MyHeader", "Hi there");

                platformView.LoadUrl(url, headers);
            }
            else
            {
                platformView.LoadUrl(url);
            }

            base.ConnectHandler(platformView);
        }
    }
}