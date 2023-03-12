using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace XS.CefSharp.BoundHelper
{
    public class SimpleClass
    {
        public IJavascriptCallback Callback { get; set; }
        public string TestString { get; set; }

        public IList<SimpleSubClass> SubClasses { get; set; }
    }
}
