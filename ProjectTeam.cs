/*
Mã sinh viên: 202419010
Họ tên: Nguyễn Minh Tuấn
*/
using System;
public class ProjectTeam
{
    //Fields
    private string projectCode;
    private string projectName;
    private Employee? leader;
    private List<Employee> members;

    //Getter
    public string ProjectCode => projectCode;
    public string ProjectName => projectName;   

    //Constructor
    public ProjectTeam(string projectCode, string projectName)
    {
        this.projectCode = projectCode;
        this.projectName = projectName;
        this.leader = null;
        this.members = new List<Employee>();
    }
    public ProjectTeam(string projectCode, string projectName, Employee leader) : this(projectCode, projectName)
    {
        if (leader !=null)
        {
            this.leader = leader;
            this.members.Add(leader);
        }
    }

    //Method

        //Contains: Kiểm tra nhân sự có trong nhóm hay ko
    public bool Contains(string employeeId)
    {
        return members.Exists(m => m.Id == employeeId);
    }

        //AddMember: Thêm nhân sự vào nhóm
        public bool AddMember(Employee employee)
    {
        return AddMember(employee, false);
    }

    public bool AddMember(Employee employee, bool makeLeader)
    {
        if (employee == null) return false;

            //Không thêm trùng nhân sự
        if (Contains(employee.Id))
        {
            Console.WriteLine($"[Thất bại] Nhân sự {employee.Id} đã có trong nhóm {projectCode}.");
            return false;
        }
        members.Add(employee);
        if (makeLeader)
        {
            leader = employee; // Trưởng nhóm cũ vẫn là thành viên
        }
        return true;
    }
    
        //RemoveMember: Xóa nhân sự khỏi nhóm
    public bool RemoveMember(string employeeId)
    {
        // Ràng buộc: Không được xóa trưởng nhóm khi chưa chọn người thay thế
        if (leader != null && leader.Id == employeeId)
        {
            Console.WriteLine($"[Từ chối] Không thể xóa {employeeId} vì đang là Trưởng nhóm. Hãy đổi trưởng nhóm trước!");
            return false;
        }

        int index = members.FindIndex(m => m.Id == employeeId);
        if (index != -1)
        {
            members.RemoveAt(index);
            Console.WriteLine($"[Thành công] Đã xóa nhân sự {employeeId} khỏi nhóm {projectCode}.");
            return true;
        }

        return false;
    }

        //ChangeLeader: Thay đổi trưởng nhóm
    public bool ChangeLeader(Employee newLeader)
    {
        if (newLeader == null) return false;

        // Ràng buộc: Trưởng nhóm mới phải được thêm vào nhóm nếu chưa là thành viên
        if (!Contains(newLeader.Id))
        {
            members.Add(newLeader);
        }

        leader = newLeader;
        Console.WriteLine($"[Thành công] Đã đổi trưởng nhóm {projectCode} thành {newLeader.FullName}.");
        return true;
    }
    
        //CalculateTotalMonthlyCost: Tính tổng chi phí lương của nhóm
    public double CalculateTotalMonthlyCost()
    {
        double total = 0;
        foreach (var member in members)
        {
            total += member.calculateMonthlyCost();
        }
        return total;
    }
    
        //DisplayInfo: Hiển thị thông tin nhóm
     public void DisplayTeam()
    {
        Console.WriteLine($"\n================ DỰ ÁN: {projectName} ({projectCode}) ================");
        Console.WriteLine($"Trưởng nhóm: {(leader != null ? leader.FullName + " (" + leader.Id + ")" : "Chưa có")}");
        Console.WriteLine($"Danh sách thành viên ({members.Count} người):");
        foreach (var member in members)
        {
            Console.Write("  -> ");
            member.DisplayInfo(); // Lời gọi đa hình
        }
        Console.WriteLine($"Tổng chi phí nhóm / tháng: {CalculateTotalMonthlyCost():N0} VND");
        Console.WriteLine("===================================================================\n");
    }

    ~ProjectTeam()
    {
        Console.WriteLine($"[Hủy] Nhóm dự án {projectCode} bị hủy. (Các thành viên Employee bên ngoài không bị ảnh hưởng).");
    }
}
