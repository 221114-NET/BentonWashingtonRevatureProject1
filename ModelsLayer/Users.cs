using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Users
    {
        public Users(int UserID, string Email, string UserPassword, bool Manager){
            this.UserId = UserID;
            this.Email = Email;
            this.UserPassword = UserPassword;
            this.Manager = Manager;
        }


        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public bool Manager { get; set; } = false;
    }
}