using System;
using System.Linq;
using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Queries;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace jp.tamagotchi.data.test.Queries.Test {
    public class SavePetQueryTests : IDisposable {
        private MySQLContext _context;

        public SavePetQueryTests () {
            var options = new DbContextOptionsBuilder<MySQLContext> ()
                .UseInMemoryDatabase (databaseName: "Save_Pet_Query_Tests")
                .Options;

            _context = new MySQLContext (options);
        }

        public void Dispose () {
            _context.Dispose ();
        }

        [Fact]
        public void When_Pet_Valid_And_No_Id_Should_Create_Pet () {
            var query = new SavePetQuery (_context);

            var payload = new SavePetQueryPayload () {
                Pet = new Entities.Pet () {
                Name = "foo",
                Image = "foo",
                Description = "bar",
                Package = "foo"
                }
            };

            var result = query.Query (payload);

            Assert.True (result.Sucessful);
            Assert.NotEqual (0, result.Data.Id);
            Assert.NotEmpty (_context.Pet);

        }

        [Fact]
        public void When_Pet_Valid_And_Id_Should_Update_Pet () {
            var query = new SavePetQuery (_context);

            var payload = new SavePetQueryPayload () {
                Pet = new Entities.Pet () {
                Name = "foo",
                Image = "foo",
                Description = "bar",
                Package = "foo"
                }
            };

            var result = query.Query (payload);

            payload.Pet = result.Data;
            payload.Pet.Name = "foo2";

            result = query.Query (payload);

            Assert.True (result.Sucessful);
            Assert.Equal ("foo2", result.Data.Name);
            Assert.NotEmpty (_context.Pet);

        }

        [Fact]
        public void When_Pet_With_Invalid_Id_Should_Fail () {
            var query = new SavePetQuery (_context);

            var payload = new SavePetQueryPayload () {
                Pet = new Entities.Pet () {
                Id = 1,
                Name = "foo",
                Image = "foo",
                Description = "bar",
                Package = "foo"
                }
            };

            var result = query.Query (payload);

            Assert.False (result.Sucessful);
            Assert.Empty (_context.Pet);

        }

    }
}