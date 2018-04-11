using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyBookHub.Model
{
    public class User 
    {
        [PrimaryKey, AutoIncrement]
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string contact_number { get; set; }
        public string email_id { get; set; }
        [Unique]
        public string user_name { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public int owner_id { get; set; }
        
        public User()
        {
            
        }
    }
}
