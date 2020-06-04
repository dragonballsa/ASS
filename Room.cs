using System;
using System.Collections.Generic;
using System.Text;

namespace asm_qlks
{
    class Room
    {

        public string IdRoom { get; set; }
        public string NameRoom { get; set; }
        public int PriceRoom { get; set; }
        public int NameFloor { get; set; }
        public int MaxRoom { get; set; }
        

        public Room() { 
        }
        public Room(string idroom, string nameroom, int priceroom, int namefloor, int maxroom)
        {
            IdRoom = idroom;
            NameRoom = nameroom;
            PriceRoom = priceroom;
            NameFloor = namefloor;
            MaxRoom = maxroom;
         
        }
        public void Display()
        {
            Console.WriteLine("idroom={0}, nameroom={1}, priceroom={2}, namefoor={3}, maxroom={4}", IdRoom, NameRoom, PriceRoom, NameFloor, MaxRoom);
        }
        public void Input()
        {
            Console.WriteLine("intput idroom:");
            IdRoom = Console.ReadLine();
            Console.WriteLine("input nameroom:");
            NameRoom = Console.ReadLine();
            Console.WriteLine("inpput priceroom");
            PriceRoom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input namefloor:");
            NameFloor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input maxroom");
            MaxRoom = Convert.ToInt32(Console.ReadLine());
          
        }

        internal void display()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            int choose;
            do
            {
                Console.WriteLine("1.Edit IDROOM");
                Console.WriteLine("2.Edit NameRoom");
                Console.WriteLine("3.Edit PriceRoom");
                Console.WriteLine("4.Edit NameFloor");
                Console.WriteLine("5.Edit MaxRoom");
                Console.WriteLine("Exit");
                Console.WriteLine("Choose:");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("input idroom:");
                        IdRoom = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("input nameroom:");
                        NameRoom = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("input priceroom:");
                        PriceRoom = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("input namefloor:");
                        NameRoom = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("input maxroom:");
                        MaxRoom = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Exited!");
                        break;
                    default:
                        Console.WriteLine("Wrong, please choose again!");
                        break;
                }
            }
            while (choose != 6);
        }

        internal void input()
        {
            throw new NotImplementedException();
        }

        internal void updateRoom()
        {
            throw new NotImplementedException();
        }
    }
}
