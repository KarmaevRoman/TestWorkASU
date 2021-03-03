using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkASU.Model
{
    class ListPossibleFunctions
    {
        private static Dictionary<string, int> listFunctions = new Dictionary<string, int>
        {
            { "линейная", 0 },
            { "квадратичная", 1 },
            { "кубическая", 2 },
            { "4-ой степени", 3 },
            { "5-ой степени", 4 }
        };

        public static Dictionary<string, int> ListFunctions { get; }

        public static ObservableCollection<string> GetListFunctions ()
        {
            var functions = new ObservableCollection<string>();
            foreach (var func in listFunctions)
                functions.Add(func.Key);
            return functions;
        }
    }     
}
