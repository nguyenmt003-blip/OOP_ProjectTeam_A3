/*
Mã sinh viên: 202419010
Họ tên: Nguyễn Minh Tuấn
*/
using System;

public class SoftwareEngineer : Employee
{
    //Fields
    private string primaryLanguage;
    private double technicalAllowance;

    //Getter
    public string PrimaryLanguage => primaryLanguage;
    public double TechnicalAllowance => technicalAllowance;

    //Constructor
    public SoftwareEngineer(string id, string fullName, string primaryLanguage) : this(id, fullName, 0.0, primaryLanguage, 0.0) { }

    public SoftwareEngineer(string id, string fullName, double baseSalary, string primaryLanguage, double technicalAllowance) : base(id, fullName, baseSalary)
    {
        if (string.IsNullOrEmpty(primaryLanguage))
            throw new ArgumentException("Ngôn ngữ lập trình chính ko đc rỗng.");
        if (technicalAllowance < 0)
            throw new ArgumentException("Phụ cấp kỹ thuật ko đc âm.");
        this.primaryLanguage = primaryLanguage;
        this.technicalAllowance = technicalAllowance;
    }
    public override double calculateMonthlyCost()
    {
        return base.calculateMonthlyCost() + technicalAllowance;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"[Software Engineer] ID: {Id} | Tên: {FullName} | Lương: {BaseSalary:N0} VND | Ngôn ngữ chính: {primaryLanguage} | Phụ cấp kỹ thuật: {technicalAllowance:N0} VND");
    }
    ~SoftwareEngineer()
    {
        Console.WriteLine($"[Software Engineer] ID: {Id} | Tên: {FullName} đã đc giải phóng.");
    }
}