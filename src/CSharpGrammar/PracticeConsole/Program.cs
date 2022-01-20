using PracticeConsole.Data; //gives reference to the location of classes within
                            //  the specified namespace
                            //this allows the developer to avoid having to
                            //  use a fully qualified name every time a
                            //  reference is made to a class in the namespace 
using System; //in .net 6 some using statement visible in .net 5 are 
              //are already implemented in the project and do not
              //need to be explicitly coded.

              //there will be times that you will still need to code
              //using statements to explcitly reference other namespaces

// See https://aka.ms/new-console-template for more information
DisplayString("Hello World!");

//Fully qualified name
//PracticeConsole.Data.Employment job = CreateJob();
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();

 static void DisplayString(string text)
{
    Console.WriteLine(text);
}

Employment CreateJob()
{
    Employment Job = null; // a reference to a variable capable of holding an
                    // instance of Employment
                    // its initial value will be null
    try
    {
        Job = new Employment();
        DisplayString($"default good job {Job.ToString()}");
        //checking exceptions
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"greedy good job {Job.ToString()}");
        //bad data: title
        //Job = new Employment("", SupervisoryLevel.Supervisor, 5.5);
        //bad data: negative Year
        //Job = new Employment("Boss", SupervisoryLevel.Supervisor, -5.5);
    }
    catch (ArgumentException ex)  //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)  //general catch all 
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return Job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress Address = new ResidentAddress();
    DisplayString($"default Address {Address.ToString()}");
    Address = new ResidentAddress(10767, "106 ST NW", null, null, "Edmonton", "AB");
    DisplayString($"greedy Address {Address.ToString()}");
    return Address;
}