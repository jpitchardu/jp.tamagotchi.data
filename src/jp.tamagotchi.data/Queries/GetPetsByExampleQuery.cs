using System;
using System.Collections.Generic;
using System.Linq;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Queries
{
    public class GetPetByExampleQuery : IQuery<GetPetByExampleQueryPayload, GetPetByExampleQueryResult>
    {

        private MySQLContext _mySqlContext;
        private MongoDBContext _mongoDBContext;

        public GetPetByExampleQuery(MySQLContext mySqlContext, MongoDBContext mongoDBContext)
        {
            _mySqlContext = mySqlContext;
            _mongoDBContext = mongoDBContext;
        }

        public GetPetByExampleQueryResult Query(GetPetByExampleQueryPayload payload)
        {

            var result = new GetPetByExampleQueryResult();

            Func<Pet, bool> predicate = entity =>
                (payload.Example?.Id ?? 0) == entity.Id &&
                (payload.Example?.Name ?? "") == entity.Name;

            try
            {
                var data = _mySqlContext.Pet.Where(predicate);

                result.Data = (payload.Size != 0 ? data.Take(payload.Size) : data).ToList();
            }
            catch (System.Exception ex)
            {
                result.AddError(ex);
            }

            return result;

        }
    }

    public class GetPetByExampleQueryPayload
    {
        public int Size { get; set; }
        public Pet Example { get; set; }
    }

    public class GetPetByExampleQueryResult : DataQueryResult<List<Pet>> { }

}