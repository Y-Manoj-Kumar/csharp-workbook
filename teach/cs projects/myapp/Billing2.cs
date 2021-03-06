using System;
using System.Linq;
using System.Collections.Generic;

class Billing2
{
#region structs
    //Declare Fruit Struct
    struct FruitStruct
    {
        public int ProductId{get;set;}
        public string ProductName{get;set;}
        public float ProductPrice{get;set;}
        public float ProductDiscount{get;set;}
    }

    //create Bill struct
    struct BillStruct
    {
        //constructors
        public BillStruct(FruitStruct _fruit, int _quantity)
        {
            Fruit = _fruit;
            Quantity = _quantity;
        }

        #region properties
        public FruitStruct Fruit{get;set;}
        public int Quantity{get;set;}
        
        public float BillPrice
        {
            get
            {
                return Fruit.ProductPrice * Quantity;
            }
        }

        public float BillDiscountPrice
        {
            get
            {
                return (Fruit.ProductPrice * Fruit.ProductDiscount) * Quantity;
            }
        }
        #endregion
    }
#endregion

#region class varaiables
Dictionary<int, FruitStruct> _fruitDatabase = new Dictionary<int, FruitStruct>();
List<BillStruct> _billList = new List<BillStruct>();
#endregion

    public void GenereteBill()
    {
        CreateFruitDatabase();
        ScanProductsAndCreateBill();
        PrintBill();
    }

    void CreateFruitDatabase()
    {
        //create apple instance
        FruitStruct apples = new FruitStruct();
        apples.ProductId = 1456;
        apples.ProductName = "Apples";
        apples.ProductPrice = 1.2f;
        apples.ProductDiscount = 1;
        //create mango instance
        FruitStruct mangos = new FruitStruct();
        mangos.ProductId = 2567;
        mangos.ProductName = "mangos";
        mangos.ProductPrice = 2.2f;
        mangos.ProductDiscount = 1;
        //create watermelons instance
        FruitStruct watermelons = new FruitStruct();
        watermelons.ProductId = 3234;
        watermelons.ProductName = "watermelons";
        watermelons.ProductPrice = 10.5f;
        watermelons.ProductDiscount = 0.9f;
        //create oranges instance
        FruitStruct oranges = new FruitStruct();
        oranges.ProductId = 466;
        oranges.ProductName = "oranges";
        oranges.ProductPrice = 3.5f;
        oranges.ProductDiscount = 1;

        //Create database of fruit products with ProductId as key
        _fruitDatabase.Add(apples.ProductId, apples);
        _fruitDatabase.Add(mangos.ProductId, mangos);
        _fruitDatabase.Add(watermelons.ProductId, watermelons);
        _fruitDatabase.Add(oranges.ProductId, oranges);
    }

    void ScanProductsAndCreateBill()
    {
        //Scan for products
        //------scanned item #3234-----
        int scanneditem = 3234;
        if(CheckForProductID(scanneditem))
        {
            _billList.Add(new BillStruct(_fruitDatabase[scanneditem],2)); //sending values as a value instead of creating new variable of BillStruct
        }

        //------scanned item #2567-----
        scanneditem = 2567;
        if(CheckForProductID(scanneditem))
        {
            _billList.Add(new BillStruct(_fruitDatabase[scanneditem],4));
        }
        //------scanned item #466-----
        scanneditem = 466;
        if(CheckForProductID(scanneditem))
        {
            _billList.Add(new BillStruct(_fruitDatabase[scanneditem],5));
        }
    }

    bool CheckForProductID(int productID)
    {
        if(_fruitDatabase.ContainsKey(productID))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Product ID " + productID +  " not detected");
            return false;
        }
    }

    void PrintBill()
    {
        //print Bill
        Console.WriteLine("items purchased " + _billList.Count);
        int count = 0;
        foreach(var billStruct in _billList)
        {
            count++;
            Console.WriteLine(count + " | " + billStruct.Fruit.ProductId + " | " + billStruct.Fruit.ProductName + " | " + billStruct.Quantity + " | " + billStruct.Fruit.ProductPrice + "₹ | " + billStruct.BillPrice + "₹");
        }
    }
}
