using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        EntertainmentManager eManager = new EntertainmentManager();

        eManager.Start();
    }
}



/*Progress so far:
For my Final Project so far i have been able to create all 8 classes, 4 of them are are in a parent child rlationship so this features Inheritance and polymorphism because the child 
methods can overide the parents. All of my classes have a section for variables, Constructors and methods that allow the class to have specific responsibilities
so this goes along with the idea of abstraction. My assignment also features encapsulation with in the classes by using Private and protected variables and private 
and public methods when they are necessary. The Project is now able to function in the way that i wish but the interface and error handling still needs to get improved.   */ 