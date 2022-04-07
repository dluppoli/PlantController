using System.Collections.Generic;

namespace PlantController.Models
{
    public interface IDBContext
    {
        List<Item> Items { get; set; }

        void SaveChanges();
    }
}