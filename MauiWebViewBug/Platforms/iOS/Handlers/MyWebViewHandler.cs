using Foundation;
using MauiWebViewBug.Control;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit;

namespace MauiWebViewBug.Platforms.iOS.Handlers
{
    public class MyWebViewHandler : WebViewHandler
    {
        protected override void ConnectHandler(WKWebView platformView)
        {
            var url = platformView.Url?.AbsoluteString;
            var request = new NSMutableUrlRequest();
            if (VirtualView is MyWebView webview)
            {
                if (string.IsNullOrEmpty(url))
                {
                    if (webview.Source is UrlWebViewSource src)
                    {
                        url = src.Url;
                    }
                }

                // Set HTTP header
                var headers = new NSMutableDictionary();
                if (!string.IsNullOrEmpty(webview.AuthToken))
                {
                    // Add the authorization header into the webview.
                    headers.Add(new NSString("Authorization"), new NSString(webview.AuthToken));
                }
                if (!string.IsNullOrEmpty(webview.AcceptLanguage))
                {
                    headers.Add(new NSString("Accept-Language"), new NSString(webview.AcceptLanguage));
                }
                headers.Add(new NSString("MyHeader"), new NSString("Hi there"));
                request.Headers = headers;
            }

            request.Url = new NSUrl(url);
            platformView.LoadRequest(request);

            base.ConnectHandler(platformView);
        }
    }
}