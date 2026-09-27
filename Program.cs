/*
Mã sinh viên: 202419010
Họ tên: Nguyễn Minh Tuấn
*/
using System;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("--- 1. Tạo 2 Employee bằng 2 constructor khác nhau ---");
        Employee e1 = new Employee("NV01", "Nguyễn Văn A");
        Employee e2 = new Employee("NV02", "Trần Thị B", 12000000);
    
        Console.WriteLine("\n--- 2. Tạo 2 SoftwareEngineer bằng 2 constructor khác nhau ---");
        SoftwareEngineer se1 = new SoftwareEngineer("SE01", "Lê Văn C", "C#");
        SoftwareEngineer se2 = new SoftwareEngineer("SE02", "Phạm Thị D", 18000000, "Python", 4000000);

        Console.WriteLine("\n--- 3. Tăng lương e1 số tiền cố định ---");
        e1.increaseSalary(3000000); // 0 + 3.000.000 = 3.000.000

        Console.WriteLine("\n--- 4. Tăng lương e2 theo phần trăm ---");
        e2.increaseSalary(10, true); // 12.000.000 + 10% = 13.200.000
    
        Console.WriteLine("\n--- 5. Tạo nhóm dự án không có trưởng nhóm. Với mã: DA01, tên: Hệ thống Core Banking ---");
        ProjectTeam team1 = new ProjectTeam("DA01", "Hệ thống Core Banking");

        Console.WriteLine("\n--- 6. Thêm một nhân sự vào nhóm DA01 bằng AddMember(e1) ---");
        team1.AddMember(e1);

        Console.WriteLine("\n--- 7. Thêm se1 bằng AddMember(se1, true) làm trưởng nhóm ---");
        team1.AddMember(se1, true);
       
        Console.WriteLine("\n--- 8. Thử thêm lại e1 ---");
        team1.AddMember(e1); //Sẽ báo thất bại
       

        //Thêm tiếp để danh sách đa dạng
        team1.AddMember(e2);
        team1.AddMember(se2);

        Console.WriteLine("\n--- 9. Hiển thị danh sách bằng lời gọi đa hình & 10. Tính tổng chi phí ---");
        team1.DisplayTeam();
       

        Console.WriteLine("--- 11. Thử xóa se1 trưởng nhóm hiện tại (kỳ vọng bị từ chối) ---");
        team1.RemoveMember("SE01"); //se1 đang là leader
       

        Console.WriteLine("\n--- 12. Đổi se2 làmtrưởng nhóm rồi xóa trưởng nhóm cũ se1 ---");
        team1.ChangeLeader(se2); //se2 làm trưởng nhóm mới
        team1.RemoveMember("SE01"); //Giờ se1 là thành viên thường, xóa thành công
        team1.DisplayTeam();
       

        Console.WriteLine("--- 13, 14, 15. Quan hệ kết tập: Nhân sự tồn tại độc lập khi nhóm bị hủy ---");
        CreateAndDestroyTeam2(e2); //Gọi hàm chứa khối lệnh cục bộ

        //Kích hoạt bộ thu gom rác Garbage Collector để kiểm chứng destructor
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("\n--- 15. Kiểm tra nhân sự e2 sau khi nhóm 2 bị hủy bằng e2.DisplayInfo() ---");
        e2.DisplayInfo();
        Console.WriteLine("\nNhấn phím bất kỳ để thoát chương trình...");
        Console.ReadKey(); // Chờ bấm 1 phím bất kỳ trên bàn phím
    }

    // Hàm khối lệnh cục bộ để kiểm chứng quan hệ kết tập
        static void CreateAndDestroyTeam2(Employee sharedEmp)
    {
        Console.WriteLine("\n-> Đang trong hàm tạo nhóm 2:");
        //Bước 13: Thêm nhân sự e2 đã có ở nhóm 1 vào nhóm 2
        ProjectTeam team2 = new ProjectTeam("DA02", "Ứng dụng Di động", sharedEmp);
        team2.DisplayTeam();
        Console.WriteLine("-> Thoát khỏi hàm tạo nhóm 2...");
        //Ra khỏi hàm này, biến team2 mất phạm vi và sẵn sàng bị thu gom 
    }
    
}
