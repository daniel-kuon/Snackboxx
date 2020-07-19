using System;
using Core.DatabaseModel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Core.Tests
{
    public class EnsureDatabaseExists
    {
        [Fact(Skip = "Not needed for in memory")]
        public async void UpdateDatabase()
        {
            var options =
                new DbContextOptionsBuilder<DataContext>()
                    .EnableSensitiveDataLogging()
                    //.UseInMemoryDatabase(Guid.NewGuid().ToString())
                    //.UseSqlite("DataSource=:memory:")
                    .UseSqlServer("Data Source=.;Initial Catalog=SnackboxUnitTests;Integrated Security=True")
                    .Options;
            var context = new DataContext(options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}