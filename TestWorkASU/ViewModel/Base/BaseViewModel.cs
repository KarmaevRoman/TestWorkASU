using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkASU.ViewModel.Base
{
    /// <summary>
    ///Базовый класс ViewModel проекта
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// делегат событие для остслеживания изменений свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyNamy = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyNamy));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string Property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(Property);
            return true;
        }
    }
}
