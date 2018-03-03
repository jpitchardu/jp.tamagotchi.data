using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Queries
{
    public class RegisterUserQuery : IQuery<RegisterUserQueryPayload, RegisterUserQueryResponse>
    {

        private MySQLContext _context;

        public RegisterUserQuery(MySQLContext context)
        {
            _context = context;
        }

        public RegisterUserQueryResponse Query(RegisterUserQueryPayload payload)
        {
            var result = new RegisterUserQueryResponse();

            try
            {
                result.Data = _context.User.Add(payload.User).Entity;
            }
            catch (System.Exception ex)
            {

                result.AddError(ex);
            }

            return result;
        }
    }

    public class RegisterUserQueryPayload
    {
        public User User { get; set; }
    }

    public class RegisterUserQueryResponse : DataQueryResult<User> { }

}