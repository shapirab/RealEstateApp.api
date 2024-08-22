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
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public UserRole UserRole { get; set; }
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
    }
}
