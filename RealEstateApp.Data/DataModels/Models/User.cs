using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.DataModels.Models
{
    public enum UserRole
    {
        Manager,
        RegisteredUser,
        UnregisteredCustomer
    }
    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required UserRole UserRole { get; set; }
        public string? Token { get; set; }

        public User(int userId, string username, string password, string firstname, string lastname, 
            UserRole userRole, string? token)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            UserRole = userRole;
            Token = token;
        }

        public User()
        {
            
        }
    }
}
