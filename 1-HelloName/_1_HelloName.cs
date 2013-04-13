using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class _1_HelloName
    {
        static void print(string name)
        {
            Console.WriteLine("Hello, {0}",name);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            print(name);
        }
    
}
