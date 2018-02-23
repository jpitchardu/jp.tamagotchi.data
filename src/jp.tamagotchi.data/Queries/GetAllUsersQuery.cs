using System;
using System.Collections.Generic;
using System.Linq;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Queries
{
    public class GetAllUsersQuery : IQuery<GetAllUsersQueryPayload, DataQueryResult<List<User>> >
    {

        private MySQLContext _context;

        public GetAllUsersQuery(MySQLContext context)
        {
            _context = context;
        }

        public DataQueryResult<List<User>> Query(GetAllUsersQueryPayload payload)
        {
            return new DataQueryResult<List<User>>()
            {
                Data = _context.User
                    .Where(entity => payload.Filters.Aggregate(true, (previousInvoke, predicate) => previousInvoke && predicate.Invoke(entity)))
                    .ToList()
            };
        }
    }

    public class GetAllUsersQueryPayload
    {
        public List<Func<User, bool>> Filters { get; set; }
    }

}