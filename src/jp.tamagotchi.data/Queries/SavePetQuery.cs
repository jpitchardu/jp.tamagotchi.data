using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Queries
{
    public class SavePetQuery : IQuery<SavePetQueryPayload, SavePetQueryResponse>
    {

        private MySQLContext _context;

        public SavePetQuery(MySQLContext context)
        {
            _context = context;
        }

        public SavePetQueryResponse Query(SavePetQueryPayload payload)
        {

            var result = new SavePetQueryResponse();

            try
            {
                result.Data = payload.Pet.Id != 0 ? _context.Pet.Add(payload.Pet).Entity : _context.Pet.Update(payload.Pet).Entity;
            }
            catch (System.Exception ex)
            {

                result.AddError(ex);
            }

            return result;

        }
    }

    public class SavePetQueryPayload
    {
        public Pet Pet { get; set; }
    }

    public class SavePetQueryResponse : DataQueryResult<Pet> { }

}