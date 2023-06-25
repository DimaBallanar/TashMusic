using MySqlConnector;
using WebApplication1.Models;
using WebApplication1.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Server.Repository
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

    public User GetUserByEmail(string email)
    {
        if (email == null) throw new ArgumentNullException(nameof(email));
        return m_Repository.GetByEmail(email);
    }

    public int Put(User user)
    {
        return m_Repository.Put(user);
    }
    public List<User> UpdateUserById(User user)
    {
        return m_Repository.Update(user);
    }

    public List<User> DeleteUser(int id)
    {
        return m_Repository.Delete(id);
    }
}

