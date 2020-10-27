namespace small_online_store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bag
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}
