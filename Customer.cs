using System;
using System.Collections.Generic;
using System.Text;

namespace asm_qlks
{
    class Customer
    {
        public int CMND { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public object Identitycard { get; internal set; }

        public Customer()
        {
        }
        public Customer(int cmnd, string fullname, int age, string gender, string address)
        {
            CMND = cmnd;
            Fullname = fullname;
            Age = age;
            Gender = gender;
            Address = address;
        }
        public void Display()
        {
            Console.WriteLine("CMND={0}, Fullname={1}, Age={2}, Gender={3}, Address={4}", CMND, Fullname, Age, Gender, Address);
        }
        public void input()
        {
            Console.WriteLine("input CMND:");
            CMND = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input Fullname:");
            Fullname = Console.ReadLine();
            Console.WriteLine("input Age:");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input Gender:");
            Gender = Console.ReadLine();
            Console.WriteLine("input Address:");
            Address = Console.ReadLine();
        }
        public void input2()
        {
            Console.WriteLine("input Fullname:");
            Fullname = Console.ReadLine();
            Console.WriteLine("input Age:");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input Gender:");
            Gender = Console.ReadLine();
            Console.WriteLine("input Address:");
            Address = Console.ReadLine();
        }

        internal void display()
        {
            throw new NotImplementedException();
        }
    }

}
