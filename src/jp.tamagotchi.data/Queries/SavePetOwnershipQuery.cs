using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

using MongoDB.Driver;

namespace jp.tamagotchi.data.Queries
{
    public class SavePetOwnershipQuery : IQuery<SavePetOwnershipQueryPayload, SavePetOwnershipQueryResult>
    {

        private MongoDBContext _context;

        public SavePetOwnershipQuery(MongoDBContext context)
        {
            _context = context;
        }

        public SavePetOwnershipQueryResult Query(SavePetOwnershipQueryPayload payload)
        {
            var result = new SavePetOwnershipQueryResult();
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

    public class SavePetOwnershipQueryPayload
    {
        public PetOwnership PetOwnership
        {
            get;
            set;
        }
    }

    public class SavePetOwnershipQueryResult : DataQueryResult<PetOwnership> { }
}