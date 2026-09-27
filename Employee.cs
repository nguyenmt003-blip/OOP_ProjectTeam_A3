/*
Mã sinh viên: 202419010
Họ tên: Nguyễn Minh Tuấn
*/
using System;
public class Employee
{
    //Fields  
    private string fullName;
    private string id;
    private double baseSalary;

    //Getter
    public string Id => id;
    public string FullName => fullName;
    public double BaseSalary => baseSalary;

    //Constructor 1: Mặc định
    public Employee() : this("UNKNOWN", "Unnamed employee", 0) {}

    //Constructor 2: 
    public Employee(string id, string fullName) : this (id, fullName, 0) {}

    //Constructor 3:
    public Employee(string id, string fullName, double baseSalary)
    {
        if (string.IsNullOrEmpty(id))
             throw new ArgumentException("Mã nhân sự ko đc rỗng.");
        if (string.IsNullOrEmpty(fullName))
            throw new ArgumentException("Tên nhân sự ko đc rỗng.");
        if (baseSalary < 0)
            throw new ArgumentException("Lương cơ bản ko đc âm.");
        this.id = id;
        this.fullName = fullName;
        this.baseSalary = baseSalary;
    }

//Method
    //increaseSalary: Tăng số tiền cố định
public void increaseSalary(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Số tiền tăng lương ko đc âm.");
        baseSalary += amount;
    }
    //increaseSalary: Tăng theo phần trăm nếu true, tăng theo số tiền cố định nếu false
public void increaseSalary(double value, bool byPercentage)
    {
        if (value <0)
            throw new ArgumentException("Số tiền tăng lương ko đc âm.");
        if (byPercentage)
        {
            baseSalary += baseSalary * value / 100;
        }
        else
        {
            baseSalary += value;
        }
    }
    public virtual double calculateMonthlyCost()
    {
        return baseSalary;
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"[Employee] ID: {id} | Tên: {fullName} | Lương: {baseSalary:N0} VND");
    }
    
    //Destructor
    ~Employee()
    {
        Console.WriteLine($"[Employee] ID: {id} | Tên: {fullName} đã đc giải phóng");
    } 
}
