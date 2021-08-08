using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models.Constant
{
    public class CVCConstants
    {
        public const string SessionName = "_User";

        public static List<Users> Users = new List<Users>
        {
            new Users { Id = 1, Name="Ritesh", Email = "ritesh@yopmail.com",Password = "12345",Roles = Roles.Developer },
            new Users { Id = 2,Name="Vidya", Email = "vidya@Yopmail.com", Password = "12345", Roles = Roles.Customer},
            new Users { Id = 3,Name="Raj", Email = "raj@Yopmail.com", Password = "12345", Roles = Roles.Customer}
        };


    }
    public class UserSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Roles Roles { get; set; }
    }
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
    }
}
