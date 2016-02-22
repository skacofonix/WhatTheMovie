﻿using System.Web.Http;
using Newtonsoft.Json;

namespace WTM.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SerializeSettings(GlobalConfiguration.Configuration);
        }

        void SerializeSettings(HttpConfiguration config)
        {
            var jsonSetting = new JsonSerializerSettings();
            jsonSetting.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings = jsonSetting;
        }
    }
}
