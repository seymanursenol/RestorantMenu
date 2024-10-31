using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_server.Data.Entity
{
    #nullable disable
    public class Menu
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        public string EatName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image {get; set;}
    }
}