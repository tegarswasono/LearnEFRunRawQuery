using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFRunRawQuery.Module.EntityFramework.Entities
{
    public class AdultProduct
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public long Stok { set; get; }
        public double Price { set; get; }
    }
}
