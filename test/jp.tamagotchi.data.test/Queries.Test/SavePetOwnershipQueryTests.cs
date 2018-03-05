using System;
using System.Threading;
using FakeItEasy;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;
using jp.tamagotchi.data.Queries;

using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace jp.tamagotchi.data.test.Queries.Test
{
    public class SavePetOwnershipQueryTests
    {
        [Fact]
        public void When_PetOwnership_Valid_Should_Save()
        {
            // var contextFake = A.Fake<MongoDBContext>();
            // // var collectionFake  = A.Fake<IMongoCollection<PetOwnership>>();

            // A.CallTo(() => contextFake.GetCollection<PetOwnership>("petOwnership")).Returns(collectionFake);

            // var query = new SavePetOwnershipQuery(contextFake);

            // var payload = new SavePetOwnershipQueryPayload()
            // {
            //     PetOwnership = new PetOwnership()
            //     {
            //         UserId = 1,
            //             PetId = 2,
            //             Active = true,
            //             DateCreated = DateTime.Today
            //     }
            // };

            // var result = query.Query(payload);

            // Assert.True(result.Sucessful);
            // A.CallTo(() => collectionFake.InsertOne(payload.PetOwnership, null, CancellationToken.None)).MustHaveHappened();

        }
    }
    
}