using System;
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

            Func<Pet, bool> predicate = entity =>
                (payload.Example?.Id ?? 0) == entity.Id &&
                (payload.Example?.Name ?? "") == entity.Name;

            return new GetPetByExampleQueryResult() { Data = _mySqlContext.Pet.Where(predicate).FirstOrDefault() };

        }
    }

    public class GetPetByExampleQueryPayload
    {
        public Pet Example { get; set; }
    }

    public class GetPetByExampleQueryResult : DataQueryResult<Pet>
    {

    }

}