using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Algorithms
    {
        private static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];
            int i = lo, j = mid + 1;
            for(int k = lo; k <= hi; k++)
            {
                if (i > mid)                                a[k] = aux[j++];
                else if (j > hi)                            a[k] = aux[i++];
                else if (aux[j].CompareTo(aux[i]) == -1)    a[k] = aux[j++];
                else                                        a[k] = aux[i++];
            }
        }

        private static void sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo)  return;
            int mid = lo + (hi - lo) / 2;
            sort(a, aux, lo, mid);
            sort(a, aux, mid + 1, hi);
            merge(a, aux, lo, mid, hi);
        }

        public static void sort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            sort(a, aux, 0, a.Length-1);
        }


        public static Element Search(ref List<Element> elements, int ID)
        {
            int min = 0;
            int max = elements.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (ID == elements[mid].ID)
                {
                    Element el = elements[mid];
                    elements.Remove(elements[mid]);
                    return el;
                }
                else if (ID < elements[mid].ID)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return null;
        }
    }
}
