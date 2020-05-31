namespace ExampleWPFValidation
{
    public class Person : ValidatableBindableBase<Person>
    {
        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set 
            { 
                SetProperty(ref _FirstName, value); 
                RaisePropertyChanged(nameof(FullName)); 
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set 
            { 
                SetProperty(ref _LastName, value);
                RaisePropertyChanged(nameof(FullName));
            }
        }

        public string FullName { get { return _FirstName + " " + _LastName; } }

    }
}
