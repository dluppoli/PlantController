using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Models
{
    public static class Items
    {
        public static ItemsList getAllItems()
        {
            DBContext context = new DBContext();
            ItemsList result = new ItemsList(context.Items.ToList());
            return result;
        }

        
        public static ItemsList getAllWithShippingDate()
        {
            //Data di spedizione calcolata come data dell'ordiine + 10gg. Se cade di sabato/domenica si sposta al lunedì successivo
            ItemsList result = getAllItems();

            foreach(Item i in result)
            {
                DateTime shippingDate = i.OrderDate.AddDays(10);

                if (shippingDate.DayOfWeek == DayOfWeek.Saturday) shippingDate = shippingDate.AddDays(2);
                if (shippingDate.DayOfWeek == DayOfWeek.Sunday) shippingDate = shippingDate.AddDays(1);

                i.ShippingDate = shippingDate;
            }

            return result;
        }

        public static void addItem(Item newItem)
        {
            DBContext context = new DBContext();

            int newId = 1;
            if (context.Items.Count() > 0) { newId = context.Items.Max(m => m.Id) + 1; }

            newItem.Id = newId;
            newItem.StateId = 1;

            context.Items.Add(newItem);
            context.SaveChanges();
        }


        public static void WriteCsv(ItemsList items, string fileName)
        {
            var header = new string[] { GetCsvHeader() };
            IEnumerable<string> csvItems = header.Concat(items.CsvFormat);
            File.WriteAllLines(fileName, csvItems);
        }

        public static string GetCsvHeader()
        {
            string sep = ";";
            return "Id" + sep + "Code" + sep + "Name" + sep + "Quantity" + sep + "Data_Ordine" + sep + "StateId" ;
        }
    }
}
