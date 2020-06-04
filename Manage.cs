using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace asm_qlks
{
    class Manage
    {
        public static void InputInforHotel(List<Hotel> listHotel)
        {
            Console.WriteLine("input N hotel:");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i =0; i < n; i++)
            {
                Hotel hotel = new Hotel();
                hotel.inputHotel();
                listHotel.Add(hotel);
            }
        }
        public static void showInforHotel(List<Hotel> listHotel)
        {
            foreach (var item in listHotel)
            {
                item.display();
            }

        }
        public static Hotel searchByID(List<Hotel> listHotel)
        {
            Console.WriteLine("input IdHotel:");
            string IdHotel = Console.ReadLine();
            Hotel hotels = null;
            foreach (var item in listHotel)
            {
                if (item.IdHotel.Equals(IdHotel))
                {
                    hotels = item;
                    break;
                }
            }
            return hotels;
        }
        public static void DeletedHotel(List<Hotel> listHotel)
        {
            Hotel hotels = searchByID(listHotel);
            if(hotels != null)
            {
                Console.WriteLine("Deleted IdHotel={0}", hotels.IdHotel);
                listHotel.Remove(hotels);
                Console.WriteLine("List of hotels after deletion:");
                showInforHotel(listHotel);
                return;
            }
            Console.WriteLine("IdHotel does not exist!");
        }
        public static void EditHotel(List<Hotel> listHotel)
        {
            Hotel hotels = searchByID(listHotel);
            if(hotels == null)
            {
                Console.WriteLine("IdHotel does note exist!");
                return;
            }
            Console.WriteLine("Information Hotel: {0}", hotels.NameHotel);
            hotels.display();
            hotels.updateHotel();
            Console.WriteLine("After update:");
            hotels.display();
        }
        public static void showMenuCustomer(List<Customer> list)
        {
            int choose;
            do
            {
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Edit information of customer");
                Console.WriteLine("3. Delete customer");
                Console.WriteLine("4. List customer");
                Console.WriteLine("5. Exit!");
                Console.WriteLine("Choose");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        inputCustomer(list);
                        break;
                    case 2:
                        EditCustomer(list);
                        break;
                    case 3:
                        deletedCustomer(list);
                        break;
                    case 4:
                        Console.WriteLine("list customer");
                        foreach (var item in list)
                        {
                            item.display();
                        }
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Wrong!");
                        break;
                }
            }
            while (choose != 5);
        }
        public static void inputCustomer(List<Customer> list)
        {

            Console.WriteLine("input N information of customer");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Customer customer = new Customer();
                customer.input();
                customer.display();
                list.Add(customer);
            }
        }

        public static void EditCustomer(List<Customer> list)
        {
            Customer customer = searchCustomer(list);
            if (customer != null)
            {
                Console.WriteLine("Edit information of customer ");
                customer.input();
                Console.WriteLine("Infor after edit:");
                foreach (var item in list)
                {
                    item.display();
                }
                return;
            }
            Console.WriteLine("CMND does not exist");
        }

        public static Customer searchCustomer(List<Customer> list)
        {
            Console.WriteLine("Input CMND of customer");
            Customer ctm = null;
            int CMND_customer = Convert.ToInt32(Console.ReadLine());
            foreach (var item in list)
            {
                if (item.CMND.Equals(CMND_customer))
                {
                    ctm = item;
                    break;
                }
            }
            return ctm;
        }
        public static void deletedCustomer(List<Customer> list)
        {

            Customer customer = searchCustomer(list);
            if (customer != null)
            {
                Console.WriteLine("Deleted success  CMND of customer ={ 0}", customer.CMND);
                list.Remove(customer);
                return;
            }
            Console.WriteLine("CMND does not exist");
        }
        public static void FindBookingAvaiable(List<Hotel> hotels, List<Book> books)
        {
            if (hotels.Count == 0)
            {
                Console.WriteLine("no data!!!");
                return;
            }

            Hotel currentHotel = null;
            for (; ; )
            {
                foreach (Hotel hotel in hotels)
                {
                    Console.WriteLine("Ma KS: {0}, Ten KS: {1}", hotel.IdHotel, hotel.NameHotel);
                }
                string HotelCode = Console.ReadLine();
                foreach (Hotel hotel in hotels)
                {
                    if (hotel.IdHotel.Equals(HotelCode))
                    {
                        currentHotel = hotel;
                        break;
                    }
                }
                if (currentHotel != null)
                {
                    break;
                }
                Console.WriteLine("(Not Found, input again: ");
            }
            if (currentHotel.ListRoom.Count == 0)
            {
                Console.WriteLine("no data!!!");
                return;
            }

            Console.WriteLine("CheckIn day (dd/mm/YYYY): ");
            string dateTime = Console.ReadLine();
            DateTime CheckIn = DateTime.ParseExact(dateTime, "dd/MM/yyyy", null);

            Console.WriteLine("CheckOut day (dd/mm/YYYY): ");
            dateTime = Console.ReadLine();
            DateTime CheckOut = DateTime.ParseExact(dateTime, "dd/MM/yyyy", null);

            foreach (Room room in currentHotel.ListRoom)
            {
                List<Book> currentBooking = new List<Book>();
                foreach (Book book in books)
                {
                    if (book.IdHotel.Equals(currentHotel.IdHotel) && book.IdRoomHotel.Equals(room.IdRoom))
                    {
                        currentBooking.Add(book);
                    }
                }
                bool isFind = false;
                foreach (Book book in currentBooking)
                {
                    if (DateTime.Compare(book.CheckIn, CheckOut) > 0 || DateTime.Compare(book.CheckOut, CheckIn) < 0)
                    {

                    }
                    else
                    {
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)
                {
                    Console.WriteLine("Room No: {0}, Room Name: {1}", room.IdRoom, room.NameRoom);
                }
            }
        }
        public static void Booking(List<Customer> customers, List<Hotel> hotels, List<Book> listbooks)
        {
            Book book = new Book();
            book.input(customers, hotels);
            listbooks.Add(book);

        }
        public static void showInforBook(List<Book> listBook)
        {
            if (listBook.Count == 0)
            {
                Console.WriteLine("no data!");
                return;
            }
            foreach (var item in listBook)
            {
                item.display();
            }
        }
        public static void ShowMenuSearch(List<Hotel> listHotel,List<Customer> listCustomer)
        {
            int choose;
            do
            {
                Console.WriteLine("1. search hotel");
                Console.WriteLine("2. search customer");
                Console.WriteLine("3. exit");
                Console.WriteLine("Choose: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        if (listHotel.Count == 0)
                        {
                            Console.WriteLine("no data");
                            return;
                        }
                        Hotel hotels = null;
                        hotels = searchByID(listHotel);
                        if(hotels == null)
                        {
                            Console.WriteLine("id hotel wrong");
                            return;                          
                        }
                        hotels.display();
                        break;
                    case 2:
                        if (listCustomer.Count == 0)
                        {
                            Console.WriteLine("no data");
                            return;
                        }
                        Console.WriteLine("input CMND of customer:");
                        int search = Convert.ToInt32(Console.ReadLine());
                        Customer currentCustomer = null;
                        foreach (var item in listCustomer)
                        {
                            if (item.CMND == search){
                                currentCustomer = item;
                                break;
                            }
                        }
                        if(currentCustomer != null)
                        {
                            Console.WriteLine("Information of customer");
                            currentCustomer.display();
                            return;
                        }
                        Console.WriteLine("CMND does not exist!");
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("choose again!");
                        break;
                }
            } while (choose != 3);
        }
    }
}