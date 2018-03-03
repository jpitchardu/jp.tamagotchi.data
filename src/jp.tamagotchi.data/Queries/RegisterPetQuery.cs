using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Queries
{
    public class RegisterPetQuery : IQuery<RegisterPetQueryPayload, RegisterPetQueryResponse>
    {

        private MySQLContext _context;

        public RegisterPetQuery(MySQLContext context)
        {
            _context = context;
        }

        public RegisterPetQueryResponse Query(RegisterPetQueryPayload payload)
        {

            var result = new RegisterPetQueryResponse();

            try
            {
                result.Data = _context.Pet.Add(payload.Pet).Entity;
            }
            catch (System.Exception ex)
            {

                result.AddError(ex);
            }

            return result;

        }
    }

    public class RegisterPetQueryPayload
    {
        public Pet Pet { get; set; }
    }

    public class RegisterPetQueryResponse : DataQueryResult<Pet> { }

}