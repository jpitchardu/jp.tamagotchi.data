using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

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

            var collection = _context.GetCollection<PetOwnership>("petOwnership");

            try
            {
                collection.InsertOne(payload.PetOwnership);
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