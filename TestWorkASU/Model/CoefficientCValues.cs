using System;
using System.Collections.ObjectModel;

namespace TestWorkASU.Model
{
    /// <summary>
    /// статичный класс для создания коллекции возможных значений коэффициента C
    /// </summary>
    static class CValues
    {
        private static int[] listCValues = new int[] { 1, 2, 3, 4, 5 };

        /// <summary>
        /// Метод для создания коллекции значений коэффициента С
        /// </summary>
        /// <returns>
        /// возвращает коллекцию элементов
        /// </returns>
        /// <param name="degree">степень 10 в которую нужно ее возвести для расчета коэффциентов</param>
        public static ObservableCollection<int> GetCValues (int degree)
        {
            var cValues = new ObservableCollection<int>();
            foreach (var c in listCValues)
                cValues.Add((int)(c * Math.Pow(10, degree)));
            return cValues;
        }
        
       
    }
}
