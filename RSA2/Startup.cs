﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSA2.Startup))]
namespace RSA2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
