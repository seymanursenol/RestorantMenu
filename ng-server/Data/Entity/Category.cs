using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ng_server.Data.Entity
{
    #nullable disable
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}