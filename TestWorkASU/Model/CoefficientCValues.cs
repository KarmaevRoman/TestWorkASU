using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkASU.Model
{
    static class CValues
    {
        private static int[] listCValues = new int[] { 1, 2, 3, 4, 5 };
        public static int[] ListCValues { get; }

        public static ObservableCollection<int> GetCValues (int degree)
        {
            var cValues = new ObservableCollection<int>();
            foreach (var c in listCValues)
                cValues.Add((int)(c * Math.Pow(10, degree)));
            return cValues;
        }
        
       
    }
}
