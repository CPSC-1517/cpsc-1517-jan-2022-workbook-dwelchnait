using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole
{
    public static class Utilities
    {
        //these types of classes should not hold and retain data
        //"static" makes only one active copy of the class
        //      when the program runs
        //when using a static class, the developer does NOT create
        //      an individual instance, instead the developer will
        //      reference items in the static class by ClassName.Method()

        public static bool IsEmpty(string value)
        {
            bool valid = false;
            if (string.IsNullOrWhiteSpace(value))
            {
                valid = true;
            }
            return valid;
        }

        //overloaded methods
        public static bool IsPositive(int value)
        {
            bool valid = false;
            if (value >= 0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsPositive(double value)
        {
            bool valid = false;
            if (value >= 0.0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsPositive(decimal value)
        {
            bool valid = false;
            if (value >= 0.0m)
            {
                valid = true;
            }
            return valid;
        }
    }
}
