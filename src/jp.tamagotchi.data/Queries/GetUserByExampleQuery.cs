using System;
using System.Collections.Generic;
using System.Linq;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

using MongoDB.Driver;

namespace jp.tamagotchi.data.Queries
{
    public class GetUserByExampleQuery : IQuery<GetUserByExampleQueryPayload, GetUserByExampleQueryResult>
    {

        private MySQLContext _mySqlContext;
        private MongoDBContext _mongoDBContext;

        public GetUserByExampleQuery(MySQLContext mySqlContext, MongoDBContext mongoDBContext)
        {
            _mySqlContext = mySqlContext;
            _mongoDBContext = mongoDBContext;
        }

        GetUserByExampleQueryResult IQuery<GetUserByExampleQueryPayload, GetUserByExampleQueryResult>.Query(GetUserByExampleQueryPayload payload)
        {

            Func<User, bool> predicate = entity =>
                (payload.Example?.Id ?? 0) == entity.Id &&
                (payload.Example?.UserName ?? "") == entity.UserName &&
                (payload.Example?.Password ?? "") == entity.Password &&
                (payload.Example?.Email ?? "") == entity.Email;

            Func<User, List<PetOwnership>> getPets = user => _mongoDBContext.GetCollection<PetOwnership>("petOwnerships")
                .AsQueryable()
                .Where(document => document.UserId == user.Id)
                .ToList();

            return new GetUserByExampleQueryResult()
            {
                Data = _mySqlContext.User.Where(predicate)
                    .Select(user => new GetUserByExampleQueryResultData() { User = user, Pets = getPets(user) })
                    .FirstOrDefault()
            };

        }
    }

    public class GetUserByExampleQueryPayload
    {
        public User Example { get; set; }
    }

    public class GetUserByExampleQueryResult : DataQueryResult<GetUserByExampleQueryResultData>
    { }

    public class GetUserByExampleQueryResultData
    {
        public User User { get; set; }
        public List<PetOwnership> Pets { get; set; }
    }

}