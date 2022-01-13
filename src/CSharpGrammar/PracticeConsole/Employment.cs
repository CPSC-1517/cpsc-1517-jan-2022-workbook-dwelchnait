using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    
    public class Employment
    {


        //An instance of this class will hold data about a person's employment
        //The code of this class is the definition of that data
        //The characteristics (data) of the class
        //  Title, SupervisoryLevel, Years of Employement within the company

        //the 4 components of a class definition are
        //  data fields
        //  property
        //  constructor
        //  behaviour (method)

        //data fields
        //  are storage area in your class
        //  these are treated as variables
        //  these may be public, private, public readonly
        private string _Title;
        private double _Years;

        //properties
        //These are access techniques to retrieve or set data in 
        //  your class without directly touching the storage data field

        //fully implemented property
        //  a) a declared stroage area (data field)
        //  b) a declared property signature
        //  c) a coded get "method"
        //  d) an optional coded set "method"

        //When:
        //  a) if you are storing the associate data in an explicitly declared data field
        //  b) if you are during validation access incoming data
        //  c) creating a property that generates output from other data sources
        //      within the class (readonly properties); this property would have only
        //      a get method
        public string Title
        {
            get
            {
                //accessor
                //the get "method" will return the contents of a data field(s)
                //  as an expression
                return _Title;
            }
            set
            {
                //mutator
                //the set "method" receives an incoming value and places it in the
                //  associated data field
                //during the setting, you might wish to validate the incoming data
                //during the setting, you might wish to do some type of logical
                //      processing using the data to set another field
                //the incoming piece of data is referred to using the keyword "value"

                //ensure that the incoming data is not null or empty or just whitespace
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                //data is considered valid
                _Title = value;
                
               
            }
        }


        //auto-implemented property

        //these properties differ only in syntax
        //each property is responsible for a single piece of data
        //thes properties do NOT reference a declared private data memver
        //the system generates an internal storage area of the return data type
        //the system manages the internal storage for the accessor and mutator
        //this is NO additional logic applied to the data value

        public int Level { get; set; }

        //this property Years could be coded as either a fully implemented property
        //  or as an auto-implmented property
        public double Years
        {
            get { return _Years; }
            set { _Years = value; }
        }


        //constructors



        //Behaviours
    }
}
