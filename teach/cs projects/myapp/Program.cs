﻿using System;
using System.Linq;

namespace myapp
{
    class Practice
    {
        public void Start()
        {
            Function1();
        }

        void Function1()
        {
            Console.WriteLine(" boo yeah");
        }

    }

    class Program
    {

        static void Main()
        {
            Console.WriteLine("Entry point");

            // var bill = new Billing();
            // bill.GenereteBill();

            // var market = new MarketPrices();
            // market.Function1();

            var access = new Accesbility();
            access.Class_Funtion1();

        }
    }
}
