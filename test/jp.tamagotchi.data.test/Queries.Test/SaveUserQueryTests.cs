using System;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Queries;

using Microsoft.EntityFrameworkCore;

using Xunit;

namespace jp.tamagotchi.data.test.Queries.Test
{
    public class SaveUserQueryTests : IDisposable
    {
        private MySQLContext _context;

        public SaveUserQueryTests()
        {
            var options = new DbContextOptionsBuilder<MySQLContext>()
                .UseInMemoryDatabase(databaseName: "Save_User_Query_Tests")
                .Options;

            _context = new MySQLContext(options);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void When_User_Valid_And_No_Id_Should_Create_User()
        {
            var query = new SaveUserQuery(_context);

            var payload = new SaveUserQueryPayload()
            {
                User = new Entities.User()
                {
                UserName = "foo",
                Password = "bar",
                Email = "foo.bar@mail.com"
                }
            };

            var result = query.Query(payload);

            Assert.True(result.Sucessful);
            Assert.NotEqual(0, result.Data.Id);

        }

        [Fact]
        public void When_User_Valid_And_Id_Should_Update_User()
        {
            var query = new SaveUserQuery(_context);

            var payload = new SaveUserQueryPayload()
            {
                User = new Entities.User()
                {
                UserName = "foo",
                Password = "bar",
                Email = "foo.bar@mail.com"
                }
            };

            var result = query.Query(payload);

            payload.User = result.Data;
            payload.User.Email = "foo.bar@mail2.com";

            result = query.Query(payload);

            Assert.True(result.Sucessful);
            Assert.Equal("foo.bar@mail2.com", result.Data.Email);

        }

    }
}