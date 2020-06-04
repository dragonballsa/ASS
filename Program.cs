using System;
using System.Collections.Generic;
using System.Text;

namespace asm_qlks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int choose;
            List<Hotel> hotelList = new List<Hotel>();
            var listCustomers = new List<Customer>();
            List<Book> listBooks = new List<Book>();

            do
            {
                showAllMenu();
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        showmenu(hotelList);

                        break;
                    case 2:
                        Manage.showMenuCustomer(listCustomers);
                        break;
                    case 3:
                        showBooking(hotelList, listBooks, listCustomers);
                        break;
                    case 4:
                        Manage.ShowMenuSearch(hotelList, listCustomers);
                        break;

                }

            } while (choose != 5);
        }

        public static void showmenu(List<Hotel> list)
        {
            int choose;

            do
            {
                Console.WriteLine("1. Add hotel");
                Console.WriteLine("2. Edit Hotel");
                Console.WriteLine("3. Delete Hotel");
                Console.WriteLine("4. Exit!");

                Console.WriteLine("Choose:");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Manage.InputInforHotel(list);
                        Manage.showInforHotel(list);
                        break;
                    case 2:
                        Manage.EditHotel(list);
                        break;
                    case 3:
                        Manage.DeletedHotel(list);
                        break;
                    case 4:

                        break;
                    default:
                        Console.WriteLine("Wrong!");
                        break;

                }
            } while (choose != 4);


        }
        public static void showAllMenu()
        {
            Console.WriteLine("1.Hotel management");
            Console.WriteLine("2.Customer Management");
            Console.WriteLine("3.Book Room Management");
            Console.WriteLine("4.Search");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Choose :");
        }

        public static void showBooking(List<Hotel> listHotel, List<Book> listBooks, List<Customer> customers)
        {
            int choose;
            do
            {
                Console.WriteLine("1. Find the room");
                Console.WriteLine("2. Book rom");
                Console.WriteLine("3. Infor of room have been booked");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Manage.FindBookingAvaiable(listHotel, listBooks);
                        break;
                    case 2:
                        Manage.Booking(customers, listHotel, listBooks);
                        break;
                    case 3:
                        Manage.showInforBook(listBooks);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Choose again!");
                        break;
                }
            } while (choose != 4);

        }
    }
}