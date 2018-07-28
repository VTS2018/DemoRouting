using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace DemoRouting
{
    public class MyPage : IHttpHandler
    {
        public RequestContext RequestContext
        {
            get;
            private set;
        }

        public MyPage(RequestContext context)
        {
            this.RequestContext = context;
        }

        #region IHttpHandler 成员

        public virtual void ProcessRequest(HttpContext context)
        {
            string path = RequestContext.RouteData.Values["page"].ToString().Replace("_", "/") + ".aspx";

            context.Server.Execute(path);
        }

        public bool IsReusable
        {
            get { return false; }
        }
        #endregion
    }

    public class MyRouteHandler : IRouteHandler
    {
        #region IRouteHandler 成员

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MyPage(requestContext);
        }
        #endregion
    }
}