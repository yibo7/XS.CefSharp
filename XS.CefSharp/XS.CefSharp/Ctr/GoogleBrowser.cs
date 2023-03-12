using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms; 

namespace XS.CefSharp
{
    public partial class GoogleBrowser : UserControl
    {
        public GoogleBrowser()
        {
            InitializeComponent();
            //不能在用户控件中直接加载谷歌内核浏览器控件初始化的代码，必须到使用用户控件的页面中调用该方法。否则拖放用户控件时会报错。
            //Load += OnLoad;
            //this.

        }
        public void InitBrowser()
        {
            creatBrowser("");
        }

        public void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }

        public void LoadHtml(string html)
        {
            browser.LoadHtml(html);
        }
        public ChromiumWebBrowser browser;
        private void creatBrowser(string url)
        {
            var settings = new CefSettings
            {
                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN",
                MultiThreadedMessageLoop = true
            };
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser(url);
            panel1.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            //browser.JavascriptObjectRepository.Register("bound", new BoundObject());
            

        }
        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {

            string msg = string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message);

        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            //MessageBox.Show("fff");

        }

        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            //MessageBox.Show("fff");

            //SetCanGoBack(args.CanGoBack);
            //SetCanGoForward(args.CanGoForward);

            //this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));


        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            string addre = args.Address;
        }


    }
}
