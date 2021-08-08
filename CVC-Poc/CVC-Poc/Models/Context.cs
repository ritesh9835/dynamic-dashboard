using CVC_Poc.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("CVCPocCs"));
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<DisplayObject> DisaplayObjects { get; set; }
        public DbSet<DisplayScreen> DisaplayScreens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //placement config
            #region Place
            modelBuilder.Entity<DisplayScreen>()
                .Property(e => e.ObjectPlacements).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<ObjectPlacement>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            #endregion

            #region Place
            modelBuilder.Entity<DisplayObject>()
                .Property(e => e.Fields).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<string>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            #endregion
        }
    }
}
