using Android.Content;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinWebView.Control;
using XamarinWebView.Droid.Renderers;

[assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]

namespace XamarinWebView.Droid.Renderers
{
    public class MyWebViewRenderer : WebViewRenderer
    {
        public MyWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            var url = Control.Url;
            if (this.Element is MyWebView webview)
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

                Control.LoadUrl(url, headers);
            }
            else
            {
                Control.LoadUrl(url);
            }
        }
    }
}