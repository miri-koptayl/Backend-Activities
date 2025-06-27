// IUserService.cs
using Backend.CORE.entities;
using System.Collections.Generic;

namespace Backend.CORE.Iservices
{
    public interface IUserService
    {
        List<Users> GetUsers();
        Users? GetById(int id);
        Users? RemoveUser(int id);

        Users RegisterUser(string username, string email, string password, int age);
        Users? UpdateUser(int id, string username, string email, string password, int age); 
    }
}
