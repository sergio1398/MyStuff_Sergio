using System;
using System.Collections.Generic;
using System.Text;

namespace MyStuff_Sergio.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Items = new HashSet<Item>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}
