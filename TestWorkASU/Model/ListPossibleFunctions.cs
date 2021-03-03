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
        private ObservableCollection<string> listFunctions;
        public ObservableCollection<string> ListFunctions
        {
            get => listFunctions;

            set => listFunctions = value;
        }

        public ListPossibleFunctions()
        {
            listFunctions = new ObservableCollection<string> { "линейная", "квадратичная", "кубическая", "4-ой степени", "5-ой степени" };
        }
    }
}
