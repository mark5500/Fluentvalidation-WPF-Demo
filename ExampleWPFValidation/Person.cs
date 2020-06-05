namespace ExampleWPFValidation
{
    public class Person : ValidatableBindableBase<Person>
    {
        private string _firstName;
        private string _lastName;
        private Pet _pet;

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                SetProperty(ref _firstName, value); 
                RaisePropertyChanged(nameof(FullName)); 
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                RaisePropertyChanged(nameof(FullName));
            }
        }

        public Pet Pet
        {
            get { return _pet; }
            set
            {
                SetProperty(ref _pet, value);
            }
        }

        public string FullName { get { return _firstName + " " + _lastName; } }

    }
}
