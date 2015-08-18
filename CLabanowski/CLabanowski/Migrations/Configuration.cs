using CLabanowski.Models;
using CLabanowski.Models.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CLabanowski.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CLabanowskiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void Seed(CLabanowskiContext context)
        {
        }
    }
}
