using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinTrackerWebServices
{
    interface IUserRepository
    {

    }

    public class UserRepository : IUserRepository
    {

        private static readonly List<User> users = new List<User>();

        private static int nextId = 0;


        public void Add(User user)
        {
            user.UserId = nextId;

            nextId++;

            users.Add(user);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return users.AsReadOnly();
        }

        public User GetById(int id)
        {
            User user = users.SingleOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return null;
            }
            return new User { Goal = user.Goal, Name = user.Name, UserId = user.UserId, Total = user.Total };
        }

        public void Save(User updatedUser)
        {
            User originalUser = users.SingleOrDefault(u => u.UserId == updatedUser.UserId);

            if (originalUser == null)
            {
                return;
            }

            originalUser.Name = updatedUser.Name;
            originalUser.Total = updatedUser.Total;
            originalUser.Goal = updatedUser.Goal;

        }




    }




}
