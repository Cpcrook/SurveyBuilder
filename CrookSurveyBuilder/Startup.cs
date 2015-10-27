using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrookSurveyBuilder.Models.Entities;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CrookSurveyBuilder.Startup))]

namespace CrookSurveyBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          //  Database.SetInitializer(new NullDatabaseInitializer<SurveyBuilderContext>());
        }
    }
}
