using System;
using System.Collections.Generic;
using System.Text;

namespace asm_qlks
{
    class Book
    {
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
        public int CMND { get; set; }
        public String IdHotel { get; set; }
        public string IdRoomHotel { get; set; }
        public DateTime CheckIn { get; private set; }
        public object Id_hotel { get; internal set; }

        public Book()
        {
        }
        public void display()
        {
            Console.WriteLine("CheckIn={0}, CheckOut={1}, CMND={2}, IdHotel={3}, IdRoomHotel={4}", Checkin, CheckOut, CMND, IdHotel, IdRoomHotel);

        }
        public void input(List<Customer> listCustomers, List<Hotel> hotels)
        {
            if (hotels.Count == 0)
            {
                Console.WriteLine("No Data!");
                return;
            }
            Console.WriteLine("Nhap CMND:");
            CMND = Convert.ToInt32(Console.ReadLine());
            bool ischeck = false;
            foreach (var item in listCustomers)
            {
                if (item.CMND.Equals(CMND))
                {
                    ischeck = true;
                    break;
                }
            }
            if (!ischeck)
            {
                Customer customer = new Customer();
                customer.CMND = CMND;
                customer.input2();
                listCustomers.Add(customer);

            }
            Hotel currentHotel = null;
            for (; ; )
            {
                Console.WriteLine("List Hotel:");
                foreach (var item in hotels)
                {
                    Console.WriteLine("IDKS={0}, TenKS={1}", item.IdHotel, item.NameHotel);
                }
                Console.WriteLine("input idhotel:");
                IdHotel = Console.ReadLine();
                foreach (var item in hotels)
                {
                    if (item.IdHotel.Equals(IdHotel))
                    {
                        currentHotel = item;
                        break;
                    }
                }
                if (currentHotel == null)
                {
                    Console.WriteLine("Wrong, please input again");
                }
                else
                {
                    break;
                }
            }
            if (currentHotel.ListRoom.Count == 0)
            {
                Console.WriteLine("no room!");
                return;
            }
            for (; ; )
            {
                foreach (var item in currentHotel.ListRoom)
                {
                        Console.WriteLine("Id_room={0}, Name_room={1}", item.IdRoom, item.NameRoom);
                }
                var isFind = false;
                Console.WriteLine("input IdRoomHotel:");
                IdRoomHotel = Console.ReadLine();
                foreach (var item in currentHotel.ListRoom)
                {
                    if (item.IdRoom.Equals(IdRoomHotel))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not Found, Input Again");
                }

            }

            Console.WriteLine("checkin day (dd/mm/yyyy)");
            string dateTime = Console.ReadLine();
            CheckIn = ConvertStringToDatetime(dateTime);

            Console.WriteLine("checkin day (dd/mm/yyyy)");
            dateTime = Console.ReadLine();
            CheckOut = ConvertStringToDatetime(dateTime);
        }
        public DateTime ConvertStringToDatetime(string value)
        {
            DateTime oDate = DateTime.ParseExact(value, "dd/MM/yyyy", null);
            return oDate;
        }
    }
}