using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using XS.Core;

namespace XS.CefSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            googleBrowser1.InitBrowser();//必须先初始化
            googleBrowser1.LoadUrl("http://image.baidu.com/"); //载入百度
            InitTimer();
        }

        #region 定时器

        private Timer timer;
        int iTimeLen = 1;//记录已经执行了几秒
        int iTimeTest = 5;//尝试重复5秒
        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (o, args) =>
            {
                if (iTimeLen < iTimeTest)
                {
                    var html = googleBrowser1.browser.GetSourceAsync();
                    html.Wait();
                    /*HtmlParse hp = new HtmlParse(html.Result);
                    var nodes = hp.GetNodes("//td/a[@onclick='_alert();return false;']");
                    if (!Equals(nodes, null) && nodes.Count() > 0)
                    {
                        foreach (var node in nodes)
                        {
                           
                        }
                        timer.Stop();
                    }*/ 
                   var imgs = XS.Core.Strings.GetString.GetImgUrl(html.Result);
                    timer.Stop();
                    MessageBox.Show($"获取到图片{imgs.Count}个");
                    
                }
                else
                {
                    timer.Stop();
                }

                iTimeLen++;
            };

        }


        #endregion
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sKeyWord = "最新时事";
            googleBrowser1.browser.GetMainFrame().ExecuteJavaScriptAsync($"$('#kw').val('{sKeyWord}')");

            string sJs = @"$($('form')[0]).submit();";
            googleBrowser1.browser.GetMainFrame().ExecuteJavaScriptAsync(sJs);
            //还原时间步长
            iTimeLen = 1;
            //启动定时器
            timer.Start();
        }
    }
}
