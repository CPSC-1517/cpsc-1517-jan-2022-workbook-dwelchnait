using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Person
    {
        //example of a composite class
        //each instance of this class willrepresent an individual
        //This clas will define the following characteristics of a person
        //  First Name, Last Name, the current resident address, list of employment positions

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {if(Utilities.IsEmpty(value))
                    throw new ArgumentNullException("First name is required.");
                _FirstName = value;
            }
                
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("Last name is required.");
                _LastName = value;
            }

        }

        public ResidentAddress Address;

        public List<Employment> EmploymentPositions { get; set; }

        public Person()
        {
            //if a instance of List<T> is not created and assigned then
            //  the property will have an initial value of null
            EmploymentPositions = new List<Employment>();
        }

       
    }
}
