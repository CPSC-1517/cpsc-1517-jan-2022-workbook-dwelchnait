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
        //a composite class uses other classes in its definition
        //a composite class is recongized with the phrase "has a" class
        //this class of Person "has a" resident address

        //an inherited class extends another class in its definition
        //an inherited class is recongized with the phrase "is a" class
        // assume a general class called Transportation
        //then we can "extend" this class to more specific classes
        //      public class Vehicle : Transportation
        //      public class Bike : Transportation
        //      public class Boat : Transportation



        //each instance of this class willrepresent an individual
        //This clas will define the following characteristics of a person
        //  First Name, Last Name, the current resident address, list of employment positions

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            private set
            {
                if(Utilities.IsEmpty(value))
                    throw new ArgumentNullException("First name is required.");
                _FirstName = value;
            }
                
        }
        public string LastName
        {
            get { return _LastName; }
            private set
            {
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("Last name is required.");
                _LastName = value;
            }

        }

        //composition actually uses the other class as a property/field within
        //the definition of the class being defined
        //in this example Address is a field (data member)


        public ResidentAddress Address;

        //composition

        public List<Employment> EmploymentPositions { get; private set; }

        //public Person()
        //{
        //    //if a instance of List<T> is not created and assigned then
        //    //  the property will have an initial value of null
        //    EmploymentPositions = new List<Employment>();

        //    //option 1: assign some default value to the strings
        //    //since FirstName and LastName need to have values
        //    //you can assign default literials to the properties
        //    FirstName = "unknown";
        //    LastName = "unknown";
        //}

        //option 2
        //DO NOT code a "Default" constructor
        //Code ONLY the "Greedy" constructor
        //if only a greedy constructor exists for the class, the ONLY
        //  way to possibly create an instance for the class within
        //  the program is to use the constructor when the class instance
        //  is created

        public Person(string firstname, string lastname,
                        List<Employment> employmentpositions,
                        ResidentAddress address)
        {
            FirstName = firstname;
            LastName = lastname;
            if (employmentpositions != null)
                EmploymentPositions = employmentpositions;
            else
                //allows a null value and the class to have an
                //  empty List<T>
                EmploymentPositions = new List<Employment>();
            Address = address;
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname.Trim();
            LastName = lastname.Trim();
        }

        public void AddEmployment(Employment employment)
        {
            EmploymentPositions.Add(employment);
        }
       
    }
}
