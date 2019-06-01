using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace WpfApp1.Model
{
    public class Element: IComparable
    {
        public int ID { get; set; }
        public String ElementName { get; set; }
        public int potision { get; set; }


        public int CompareTo(object obj)
        {
            if (ID > ((Element)obj).ID)
                return 1;
            else if (ID < ((Element)obj).ID)
                return -1;
            return 0;
        }
    }
}
