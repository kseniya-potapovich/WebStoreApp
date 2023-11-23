using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreApp.Dto
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public int SellerId { get; set; }

        public string Discription { get; set; }

        public double Price { get; set; }
    }
}
