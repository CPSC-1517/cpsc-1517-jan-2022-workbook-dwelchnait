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
//DisplayString("Hello World!");

//Fully qualified name
//PracticeConsole.Data.Employment job = CreateJob();
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();

//create a Person
Person Me = CreatePerson(Job, Address);
//if (Me != null)
//    DisplayPerson(Me);

ArrayReview(Me);

 static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString($"{person.Address.ToString()}");

    //in our example, the Person constructor ensures that EmploymentPosition
    //  exists (List was declared) ; this makes the need for the null mute
    if (person.EmploymentPositions != null)
    {
        //this loop is a forward moving pre-test loop
        //what it checks is "is there another link element to look at"
        //Yes: use the element
        //No: exit loop
        foreach (var emp in person.EmploymentPositions)
        {
            DisplayString(emp.ToString());
        }

        //a List<T> can actually be manipulated like an array
        //is a pre-test loop 

        for (int i = 0; i < person.EmploymentPositions.Count; i++)
        {
            DisplayString(person.EmploymentPositions[i].ToString());
        }


        if (person.EmploymentPositions.Count > 0)
        {
            int x = 0;
            //is a post-test loop 
            do
            {
                DisplayString(person.EmploymentPositions[x].ToString());
                x++;
            } while (x < person.EmploymentPositions.Count);
        }
    }
}

Employment CreateJob()
{
    Employment Job = null; // a reference to a variable capable of holding an
                    // instance of Employment
                    // its initial value will be null
    try
    {
        Job = new Employment();
        //DisplayString($"default good job {Job.ToString()}");

        Job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        //DisplayString($"greedy good job {Job.ToString()}");

        //checking exceptions
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
    //DisplayString($"default Address {Address.ToString()}");
    Address = new ResidentAddress(10767, "106 ST NW", null, null, "Edmonton", "AB");
    //DisplayString($"greedy Address {Address.ToString()}");
    return Address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    List<Employment> Jobs = new List<Employment>();
    Person thePerson = null;
    try
    {
        //create a good person using greedy constructor no job list
       //thePerson = new Person("DonNoJob", "Welch", null, address);

        //create a good person using greedy constructor with an empty job list
        //thePerson = new Person("DonEmptyJob", "Welch", Jobs, address);

        //create a good person using greedy constructor with a job list
        
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(job);
        thePerson = new Person("DonWithJobs", "Welch", Jobs, address);

        //esception testing
        // no first name
        //thePerson = new Person(null, "Welch", Jobs, address);
        // no second name
        //thePerson = new Person("DonWithJobs", null, Jobs, address);


        //can i change the firstname using an assignment statement
        //the FirstName is a private set.
        //you are NOT allowed to use a private set on the receiving side
        //  of an assignment statement.
        //THIS WILL NOT COMPILE
        //thePerson.FirstName = "NewName";

        //can i use a behaviour (method) to change the contents of a private
        //  set property?
        thePerson.ChangeName("Lowand", "Behold");

        //can I add another job after the person instance was created
        thePerson.AddEmployment(new ("DP IT", SupervisoryLevel.DepartmentHead, 0.8));
        //thePerson.AddEmployment(new Employment("DP IT", SupervisoryLevel.DepartmentHead, 0.8));

        //change I change the public field Address directly
        ResidentAddress oldAddress = thePerson.Address;
        oldAddress.City = "Vancover";
        thePerson.Address = oldAddress;
    }
    catch (ArgumentException ex)  //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)  //general catch all 
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return thePerson;
}

void ArrayReview(Person person)
{
    //Declare a single-dimensional array size 5
    //In this declaration the value in each element is set
    //  to the datatype's default (numeric - > 0)
    int [] array1 = new int [5]; //one can use a literal for the size
    //PrintArray(array1, 5, "declare int array size 5");

    //Declare and set array elements
    int[] array2 = new int[] {1, 2, 4, 8, 16};
    //PrintArray(array2, 5, "declare int array size using a list of supplied values");

    //alternate syntax
    //size of the array can be determind using the method .Count() of the array collection 
    //  using the inherited class IEnumerable (Array class derived from the base class IEnumerable
    //  which is derived from its base class Collections)
    //size of the array can be determind using the read-only property (just has a get{}) of the
    //  Array class called .Length

    int[] array3 = { 1, 3, 6, 12, 24 };
   // PrintArray(array3, array3.Length, "declare int array with just a list of supplied values");

    //Travsering to an array altering elements
    //remember that the array when declared is physically created in memory
    //each element (cell) has a given value, even if it is the datatype default
    //when you are "adding" to an array you are really just altering the element value

    //logical counter for your array size to indicate the "valid meaningful" values for processing
    int lsarray1 = 0;
    int lsarray2 = array2.Count();  //IEnumerable method
    int lsarray3 = array3.Length;   //Array read-only property

    Random random = new Random();
    int randomvalue = 0;
    while (lsarray1 < array1.Length)
    {
        randomvalue = random.Next(0,100);
        array1[lsarray1] = randomvalue;
        lsarray1++;
    }
  //  PrintArray(array1, lsarray1, "array load with random values");

    //Alter a element randomly selected to a new value
    int  arrayposition = random.Next(0,array1.Length);
    randomvalue = random.Next(0, 100);
    array1[arrayposition] = randomvalue;
    PrintArray(array1, lsarray1, "randomly replace an array value");

    //Remove an element value from an array
    //move all array element in positions greater than the removed element position, "up one"
    //Assume we are removing element 3 (index 2)
    int logicalelementnumber = 3; //index of value is logicalposition - 1
    for (int index = --logicalelementnumber; index < array1.Length - 1; index++)
    {
        array1[index] = array1 [index + 1];
    }
    lsarray1--;
    array1[array1.Length - 1] = 0;
    PrintArray(array1, array1.Length, "remove an array value");

}


void PrintArray(int [] array, int size, string text)
{
    Console.WriteLine($"\n{text}\n");
    //item represents an element in the array
    //array is your collection (array [])
    //processing will be start (0) to end (size-1)
    foreach(var item in array)
    {
        Console.Write($"{item},");
    }
    Console.WriteLine("\n");
    //using the for loop this display output the
    //      array back to front
    for (int i = size -1; i >= 0; i--)
    {
        Console.Write($"{array[i]},");
    }
    Console.WriteLine("\n");
}