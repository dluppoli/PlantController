using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Models
{
    public class DBContext
    {
        public List<Item> Items;

        public DBContext()
        {
            Items = new List<Item>();
            DateTime today = DateTime.Today;

            Items.Add(new Item { Id = 1, Code = "A001", Name = "Articolo n. 1", Quantity = 100, StateId = 3, OrderDate = today.AddDays(-12) });
            Items.Add(new Item { Id = 2, Code = "A002", Name = "Articolo n. 2", Quantity = 100, StateId = 3, OrderDate = today.AddDays(-10) });
            Items.Add(new Item { Id = 3, Code = "A003", Name = "Articolo n. 3", Quantity = 100, StateId = 3, OrderDate = today.AddDays(-10) });
            Items.Add(new Item { Id = 4, Code = "A004", Name = "Articolo n. 4", Quantity = 100, StateId = 2, OrderDate = today.AddDays(-7) });
            Items.Add(new Item { Id = 5, Code = "A005", Name = "Articolo n. 5", Quantity = 100, StateId = 2, OrderDate = today.AddDays(-6) });
            Items.Add(new Item { Id = 6, Code = "A006", Name = "Articolo n. 6", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-5) });
            Items.Add(new Item { Id = 7, Code = "A007", Name = "Articolo n. 7", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-4) });
            Items.Add(new Item { Id = 8, Code = "A008", Name = "Articolo n. 8", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-4) });
            Items.Add(new Item { Id = 9, Code = "A009", Name = "Articolo n. 9", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-3) });
            Items.Add(new Item { Id = 10, Code = "A010", Name = "Articolo n.10", Quantity = 100, StateId = 1, OrderDate = today });
        }

        public void SaveChanges()
        {

        }
    }
}
