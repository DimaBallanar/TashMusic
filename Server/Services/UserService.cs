using MusicServer.Models.Repository;
using MusicServer.Repository;

namespace MusicServer.Services
{
    public class UserService
    {
        private readonly UserRepository m_Repository;

        public UserService(UserRepository repository)
        {
            m_Repository = repository;
        }

        public List<User> GetAll()
        { 
            return m_Repository.GetAll();
        }

        public List<User> GetAll(int id)
        {
            return m_Repository.GetAll(id);
        }

        public User GetUserByEmail(string email,string password)
        {
            if(email==null) throw new ArgumentNullException(nameof (email));
             return m_Repository.GetByEmail(email, password);
        }

        public int Put(User user)
        { 
            return m_Repository.Put(user);
        }
        public List <User> UpdateUserById(User user)
        {
            return m_Repository.Update(user);
        }

        public List<User> DeleteUser(int id)
        {
            return m_Repository.Delete(id);
        }
    }
}
