using System;
using System.Collections.Generic;

//creator file
class Bank
{
    
    #region class_fields
    private string _name;
    private long _mobileNo;

    private long _accountNo;

#region Properties
    public long AccountNo
    {
        //getter
        get
        {
            return Encrypt(_accountNo);
        }

        // //setter (string value)
        // set{
        //     Console.WriteLine("be careful with setting new value");
        //     if(value <= 1000)
        //         _accountNo = Decrypt(value);
        // }
    }

    public long Encrypt(long value)
    {
        return (value + 20);
    }

    public long Decrypt(long value)
    {
        return(value - 20);
    }

    public int BranchCode
    {
        get{return 7126;}
    }

    public string Name
    {
        get{return _name;}
    }
    #endregion //properties
    #endregion//class varibles

    public Bank(string name, long mobileNo)
    {
        _name = name;
        _mobileNo = mobileNo;

        //generate random number;
        _accountNo = 50171264789;
    }

    public Bank()
    {
        Console.WriteLine("Please enter your name: ");
        _name = Console.ReadLine();
        Console.WriteLine("Enter your Mobile no: ");
        _mobileNo = long.Parse(Console.ReadLine());

        //generate random number;
        _accountNo =  50171264789;
    }

    public void PrintDetails()
    {
        Console.WriteLine("Name: " + _name + "\nMobile No: " + _mobileNo+ "\nAccount No(Internal): " + _accountNo);
    }

    
        //
    // Summary:
    //     Gets the total number of elements in all the dimensions of the System.Array.
    //
    // Returns:
    //     The total number of elements in all the dimensions of the System.Array; zero
    //     if there are no elements in the array.
    //
    // Exceptions:
    //   T:System.OverflowException:
    //     The array is multidimensional and contains more than System.Int32.MaxValue elements.
    public long GetAccountNo()
    {
        return _accountNo;
    }
    
}