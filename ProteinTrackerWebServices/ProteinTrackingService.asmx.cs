using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProteinTrackerWebServices
{
    /// <summary>
    /// Summary description for ProteinTrackingService
    /// </summary>
    [WebService(Namespace = "http://www.robsalmon.me.uk")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
 
    public class ProteinTrackingService : WebService {

        private UserRepository repository = new UserRepository();


      [WebMethod(Description = "Add an amount to the total", EnableSession = true)]
      public int AddProtein(int amount, int userId)
        {

            var user = repository.GetById(userId);
            
            if (user == null)
            {
                return -1;
            }

            user.Total += amount;
            repository.Save(user);

            return user.Total;

        }

        [WebMethod(Description = "Add a new user", EnableSession = true)]
        public int AddUser(string name, int goal)
        {
            var user = new User { Goal = goal, Name = name, Total = 0 };

            repository.Add(user);

            return user.UserId;

        }

        [WebMethod(Description = "Return a list of users", EnableSession = true)]
        public List<User> ListUsers()
        {
            return new List<User>(repository.GetAll());
        }
    }
}
