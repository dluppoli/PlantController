using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Models
{
    public partial class Item
    {
        public bool IsSelected { get; set; }
        public DateTime? ShippingDate { get; set; } = null;

        public string State
        {
            get
            {
                switch (StateId)
                {
                    case 1:
                        return "Da produrre";
                    case 2:
                        return "In produzione";
                    case 3:
                        return "Prodotto";
                    default:
                        return "Non definito";
                }
            }
            set
            {
                switch (value)
                {
                    case "Da produrre":
                        StateId = 1;
                        break;
                    case "In produzione":
                        StateId = 2;
                        break;
                    case "Prodotto":
                        StateId = 3;
                        break;
                    default:
                        StateId = 0;
                        break;
                }
            }
        }

        public string CsvFormat
        {
            get
            {
                string sep = ";";
                return Id + sep + Code + sep + Name + sep + Quantity + sep + OrderDate.ToString("yyyyMMdd") + sep + StateId;
            }
        }

        public int DaysOld
        {
            get
            {
                if (OrderDate > DateTime.Today) return 0;

                return (DateTime.Today - OrderDate).Days;
            }
        }
    }
}
