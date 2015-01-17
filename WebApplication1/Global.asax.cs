using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using HMSDDataModel;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            System.Data.Entity.Database.SetInitializer(new HMSDContextInitialiser());

            HMSDContext db = new HMSDContext();
            db.Database.Initialize(true);
        }
    }
}
