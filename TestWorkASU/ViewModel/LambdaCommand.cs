using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkASU.ViewModel.Base;

namespace TestWorkASU.ViewModel
{
    class LambdaCommand : ButtonCommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// объявление экземпляра класса LambdaCommand
        /// </summary>
        public LambdaCommand(Action<object> Execute, Predicate<object> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }

        /// <summary>
        /// устанавливает можно ли выполнить комманду
        /// </summary>
        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// устанавливает что делает комманда
        /// </summary>
        public override void Execute(object parameter) => _execute(parameter);
    }
}
