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
        }

        public void Click()
        {
            _person.AttachValidator(new PersonValidator());

            if (_person.Validator.Validate(_person).IsValid)
            {
                MessageBox.Show("Valid");
            } 
            else
            {
                MessageBox.Show("Invalid");
            }

        }
    }
}
