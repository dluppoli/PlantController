using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Models
{
    [DebuggerDisplay("{Id} {Code} {Name}")]
    public partial class Item
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public double Quantity { get; set; }

        public int StateId { get; set; } //1-Da produrre      2-In produzione     3-Prodotto

        public DateTime OrderDate { get; set; }
    }
}
