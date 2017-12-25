using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Teamwork.Data;
using Teamwork.Web.Infrastructure.Mapping;

namespace Teamwork.Test
{
    public class TestInit
    {
        private static bool testInitialized = false;

        public static void InitializeMapper()
        {
            if (!testInitialized)
            {
                Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
                testInitialized = true;
            }
        }

        public static TeamworkDbContext InitializeInmemoryDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TeamworkDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TeamworkDbContext(dbOptions);
        }
    }
}
