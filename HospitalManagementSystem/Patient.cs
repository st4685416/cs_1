namespace HospitalManagementSystem;

public class Patient
{
    public int Id;
    public string Name;
    public int Age;
    
    public Patient(int id, string name, int age)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
    }
}