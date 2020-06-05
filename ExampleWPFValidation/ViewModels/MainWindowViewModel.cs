using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace ExampleWPFValidation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private Person _person;

        public DelegateCommand ClickCommand { get; private set; }

        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        public MainWindowViewModel()
        {
            ClickCommand = new DelegateCommand(Click);
            _person = new Person();
            _person.Pet = new Pet();
        }

        public void Click()
        {
            AttachValidators();

            var personResult = _person.Validator.Validate(_person);
            var petResult = _person.Pet.Validator.Validate(_person.Pet);

            if (personResult.IsValid && petResult.IsValid)
            {
                MessageBox.Show("Valid");
            }
            else
            {
                MessageBox.Show("Invalid");
            }

        }

        private void AttachValidators()
        {
            if (_person.Validator == null) _person.AttachValidator(new PersonValidator());
            if (_person.Pet.Validator == null) _person.Pet.AttachValidator(new PetValidator());
        }
    }
}
