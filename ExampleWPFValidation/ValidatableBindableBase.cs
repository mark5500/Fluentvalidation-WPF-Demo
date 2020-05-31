using System;
using System.ComponentModel;
using System.Linq;
using System.Collections;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using FluentValidation;

namespace ExampleWPFValidation
{
    public abstract class ValidatableBindableBase<T> : BindableBase, INotifyDataErrorInfo
    {
        public IValidator<T> Validator;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get
            {
                if (Validator == null) return false;
                var hasErrors = Validator.Validate(this).Errors.Any();
                return hasErrors;
            }
        }

        public virtual void AttachValidator(IValidator<T> validator)
        {
            this.Validator = validator;
            RaisePropertyChanged(null);
        }

        public IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            if (Validator == null) return Enumerable.Empty<object>();
            var errors = Validator.Validate(this).Errors.Where(c => c.PropertyName == propertyName);

            return errors;
        }

        protected void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            OnErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var handler = ErrorsChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
