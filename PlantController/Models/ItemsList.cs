using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Models
{
    public class ItemsList : ObservableCollection<Item>
    {
        public ItemsList() : base() { }

        public ItemsList(IEnumerable<Item> items) : base(items) {  }

        public int SelectedCount
        {
            get { return this.Count(c => c.IsSelected); }
        }
        public double Total
        {
            get { return this.Sum(s => s.Quantity); }
        }

        public double TotalByState(int stateId)
        {
            if (stateId <= 0 || stateId > 3) throw new ArgumentOutOfRangeException();

            return this.Where(w=>w.StateId==stateId).Sum(s => s.Quantity);
        }

        public IEnumerable<string> CsvFormat
        {
            get
            {
                return this.Select(s => s.CsvFormat);
            }
        }

    }
}
