using System.Security.Principal;

namespace HospitalManagementSystem;

public class Doctor
{
    public int Id;
    public string Name;
    public string Specialization;
    
    public Doctor(int id, string name, string specialization)
    {
        this.Id = id;
        this.Name = name;
        this.Specialization = specialization;
    }
}