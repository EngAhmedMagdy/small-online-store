using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace small_online_store.Models
{
    [NotMapped]
    public sealed class CurrentUser : User
    {
        //Private Constructor.  
        private CurrentUser()
        {
        }
        
        public static CurrentUser instance = null;
        public static CurrentUser GetInstance()
        {
            if (instance == null)
            {
                instance = new CurrentUser();
            }
            return instance;
        }
    } 
}