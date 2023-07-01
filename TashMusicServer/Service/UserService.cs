using System;
using MySqlConnector;
using WebApplication1.Models;
using WebApplication1.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class UserService
{
    //private readonly UserRepository _repository;
    //public UserService(UserRepository repository)
    //{
    //    _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    //}
    //public List<UserModel> GetAll()
    //{
    //    return new UserRepository().GetAllUsersFromDB(MySqlConnection c);
    //}

    //private MySqlConnection Connection()
    //{
    //    try
    //    {
    //        MySqlConnection connection = new MySqlConnection(AppSettingsHelper.ConnectionString);
    //        connection.Open();
    //        return connection;
    //    }
    //    catch (MySqlException ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //        throw new Exception("connection error");
    //    }
    //}
}
