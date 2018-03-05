using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;
using MongoDB.Driver;

namespace jp.tamagotchi.data.Queries
{
    public class RegisterPetOwnershipQuery : IQuery<RegisterPetOwnershipQueryPayload, RegisterPetOwnershipQueryResult>
    {

        private MongoDBContext _context;

        public RegisterPetOwnershipQuery(MongoDBContext context)
        {
            _context = context;
        }

        public RegisterPetOwnershipQueryResult Query(RegisterPetOwnershipQueryPayload payload)
        {
            var result = new RegisterPetOwnershipQueryResult();
            var filterBuilder = Builders<PetOwnership>.Filter;
            try
            {
                var collection = _context.GetCollection<PetOwnership>("petOwnership");

                if (payload.PetOwnership.Id == null)
                    collection.InsertOne(payload.PetOwnership);
                else
                    collection.ReplaceOne(filterBuilder.Where(x => x.Id == payload.PetOwnership.Id), payload.PetOwnership);
                
                result.Data = payload.PetOwnership;
            }
            catch (System.Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

    }

    public class RegisterPetOwnershipQueryPayload
    {
        public PetOwnership PetOwnership { get; set; }
    }

    public class RegisterPetOwnershipQueryResult : DataQueryResult<PetOwnership> { }
}