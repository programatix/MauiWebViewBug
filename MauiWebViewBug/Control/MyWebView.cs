using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWebViewBug.Control
{
    public class MyWebView : WebView
    {
        public string AuthToken { get; set; }

        public string AcceptLanguage { get; set; }
    }
}