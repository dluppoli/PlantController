using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Models
{
    public class DBContext : IDBContext
    {
        public List<Item> Items { get; set; }

        public DBContext()
        {
            Items = new List<Item>();
            DateTime today = DateTime.Today;

            Items.Add(new Item { Id = 1, Code = "A001", Name = "Confettura di pesche", Quantity = 100, StateId = 3, OrderDate = today.AddDays(-12) });
            Items.Add(new Item { Id = 2, Code = "A002", Name = "Crema spalmabile alle nocciole", Quantity = 100, StateId = 3, OrderDate = today.AddDays(-10) });
            Items.Add(new Item { Id = 3, Code = "A003", Name = "Passata di pomodoro", Quantity = 100, StateId = 3, OrderDate = today.AddDays(-10) });
            Items.Add(new Item { Id = 4, Code = "A004", Name = "Sugo ai funghi", Quantity = 100, StateId = 2, OrderDate = today.AddDays(-7) });
            Items.Add(new Item { Id = 5, Code = "A005", Name = "Confettura di fragole", Quantity = 100, StateId = 2, OrderDate = today.AddDays(-6) });
            Items.Add(new Item { Id = 6, Code = "A006", Name = "Confettura di arance", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-5) });
            Items.Add(new Item { Id = 7, Code = "A007", Name = "Succo di frutta alla pera", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-4) });
            Items.Add(new Item { Id = 8, Code = "A008", Name = "Sugo all'amatriciana", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-7) });
            Items.Add(new Item { Id = 9, Code = "A009", Name = "Succo di frutta al mirtillo", Quantity = 100, StateId = 1, OrderDate = today.AddDays(-3) });
            Items.Add(new Item { Id = 10, Code = "A010", Name = "Succo di frutta ACE", Quantity = 100, StateId = 1, OrderDate = today });
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
