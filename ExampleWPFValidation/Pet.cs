using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWPFValidation
{
    public class Pet : ValidatableBindableBase<Pet>
    {
        private string _name;
        private string _nickName;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }
    }
}
