﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WTM.Api.Startup))]

namespace WTM.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
