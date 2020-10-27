namespace small_online_store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {


        [StringLength(100)]
        public string Photo { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int? Price { get; set; }

        public int? Discount { get; set; }
        
        public bool SSize { get; set; }

        public bool MSize { get; set; }

        public bool LSize { get; set; }
        
        public int Id { get; set; }

        [StringLength(50)]
        public string type { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [StringLength(10)]
        public string Color { get; set; }
    }
}
