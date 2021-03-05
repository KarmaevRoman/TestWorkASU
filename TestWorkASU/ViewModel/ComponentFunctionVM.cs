using TestWorkASU.ViewModel.Base;
using TestWorkASU.Model;

namespace TestWorkASU.ViewModel
{
    /// <summary>
    /// класс для заполнения таблицы ListView в котором хранятся все элементы функции
    /// </summary>
    public class ComponentFunctionVM : BaseViewModel
    {
        private string nameFunction;
        private double aCoefficient;
        private double bCoefficient;
        private int cCoefficient;
        private string x = "";
        private string y = "";
        private double result;

        /// <summary>
        /// возвращает и устанавливает наименование функции
        /// </summary>
        public string NameFunction
        {
            get => nameFunction;
            set
            {
                Set(ref nameFunction,value);
                Result = CalculateResult.Result(this);
            }
        }

        /// <summary>
        /// возвращает и устанавливает коэффициент A
        /// </summary>
        public double ACoefficient
        {
            get => aCoefficient;
            set
            {
                Set(ref aCoefficient, value);
                Result = CalculateResult.Result(this);
            }
        }

        /// <summary>
        /// возвращает и устанавливает коэффициент B
        /// </summary>
        public double BCoefficient
        {
            get => bCoefficient;
            set
            {
                Set(ref bCoefficient, value);
                Result = CalculateResult.Result(this);
            }
        }

        /// <summary>
        /// возвращает и устанавливает коэффициент C
        /// </summary>
        public int CCoefficient
        {
            get => cCoefficient;
            set
            {
                Set(ref cCoefficient, value);
                Result = CalculateResult.Result(this);
            }
        }

        /// <summary>
        /// возвращает и устанавливает коэффициент X
        /// </summary>
        public string X
        {
            get => x;
            set
            {
                if (double.TryParse(value, out double a))
                {
                    Set(ref x, value);                    
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref x, "0");                    
                }
                else
                {
                    X = x;
                }                
                Result = CalculateResult.Result(this);
            }
        }

        /// <summary>
        /// возвращает и устанавливает коэффициент Y
        /// </summary>
        public string Y
        {
            get => y;
            set
            {
                if (double.TryParse(value, out double a))
                {
                    Set(ref y, value);
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref y, "0");
                }
                else
                {
                    Y = y;
                }
                Result = CalculateResult.Result(this);
            }
        }

        /// <summary>
        /// возвращает результат расчета функции по её параметрам
        /// </summary>
        public double Result
        {
            get => result;
            private set => Set(ref result, value);
        }
    }
}
