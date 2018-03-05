using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Queries
{
    public class SaveUserQuery : IQuery<SaveUserQueryPayload, SaveUserQueryResponse>
    {

        private MySQLContext _context;

        public SaveUserQuery(MySQLContext context)
        {
            _context = context;
        }

        public SaveUserQueryResponse Query(SaveUserQueryPayload payload)
        {
            var result = new SaveUserQueryResponse();

            try
            {
                result.Data = payload.User.Id == 0 ? _context.User.Add(payload.User).Entity : _context.User.Update(payload.User).Entity;
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {

                result.AddError(ex);
            }

            return result;
        }
    }

    public class SaveUserQueryPayload
    {
        public User User { get; set; }
    }

    public class SaveUserQueryResponse : DataQueryResult<User> { }

}