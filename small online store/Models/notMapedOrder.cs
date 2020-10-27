using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace small_online_store.Models
{
    [NotMapped]
    public class notMapedOrder : Order
    {
    }
}