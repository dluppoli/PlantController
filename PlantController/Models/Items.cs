using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PlantController.Models
{
    public static class Items
    {
        public static List<Tuple<DateTime, DateTime>> getHolidays()
        {
            List<Tuple<DateTime, DateTime>> result = new List<Tuple<DateTime, DateTime>>();

            result.Add(new Tuple<DateTime, DateTime>(new DateTime(2022, 04, 15), new DateTime(2022, 04, 18)));
            result.Add(new Tuple<DateTime, DateTime>(new DateTime(2022, 04, 25), new DateTime(2022, 04, 25)));
            result.Add(new Tuple<DateTime, DateTime>(new DateTime(2022, 06, 02), new DateTime(2022, 06, 03)));

            return result;
        }


        public static ItemsList getAllItems(IDBContext context)
        {
            //DBContext context = new DBContext();
            ItemsList result = new ItemsList(context.Items.ToList());
            return result;
        }
        
        public static ItemsList getAllWithShippingDate(IDBContext context)
        {
            //Data di spedizione calcolata come data dell'ordiine + 10gg. Se cade di sabato/domenica si sposta al lunedì successivo
            ItemsList result = getAllItems(context);

            List<Tuple<DateTime, DateTime>> holidays = getHolidays();


            foreach (Item i in result)
            {
                DateTime shippingDate = i.OrderDate.AddDays(10);

                foreach(Tuple<DateTime, DateTime> holiday in holidays)
                {
                    if( shippingDate>= holiday.Item1 &&
                        shippingDate <= holiday.Item2 )
                    {
                        shippingDate = holiday.Item2.AddDays(1);
                    }
                }

                if (shippingDate.DayOfWeek == DayOfWeek.Saturday) shippingDate = shippingDate.AddDays(2);
                if (shippingDate.DayOfWeek == DayOfWeek.Sunday) shippingDate = shippingDate.AddDays(1);

                i.ShippingDate = shippingDate;
            }

            return result;
        }

        public static void addItem(Item newItem)
        {
            try
            {
                DBContext context = new DBContext();

                int newId = 1;
                if (context.Items.Count() > 0) { newId = context.Items.Max(m => m.Id) + 1; }

                newItem.Id = newId;
                newItem.StateId = 1;

                context.Items.Add(newItem);
                context.SaveChanges();
            }
            catch(NotImplementedException e)
            {
                throw new SystemException("Errore nell'aggiunta dell'elemento",e);
            }
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
