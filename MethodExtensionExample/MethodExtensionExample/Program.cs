using MethodExtensionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodExtensionExample.Extensions;

namespace MethodExtensionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greater than
            int numA = 18;
            int numB = 20;
            bool resultGreater = numA.IsGreaterThan(numB);
            Console.WriteLine("Is " + numA + " Greater than " + numB + ": " + resultGreater);

            //Between
            int numC = 21;
            int numD = 20;
            int numE = 25;
            bool resultBetween = numC.IsBetween(numD, numE);
            Console.WriteLine("Is " + numC + " between " + numD + " and "+ numE + ": " + resultBetween);

            //call to the second example
            ExampleIEnumerableExtension();

            //stop the console until Enter key 
            Console.ReadLine();
        }

        public static void ExampleIEnumerableExtension()
        {
            var data = new List<Participants> {
               new Participants { Id = 123, Name = "Lucas", Email = "lucas@email.com", IsAdmin = true },
               new Participants { Id = 32, Name = "Patrick", Email = "patrick@email.com", IsAdmin = true },
               new Participants { Id = 23, Name = "George", Email = "george@email.com", IsAdmin = false },
               new Participants { Id = 5, Name = "Louis", Email = "louis@email.com", IsAdmin = true }
            };

            var ColumnsArray = data.ToColumnsArray();

            /* Do Whatever you want here with your helper :), I needed to send it to the Database */
        }
    }
}
