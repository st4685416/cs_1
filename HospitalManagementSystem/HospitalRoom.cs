namespace HospitalManagementSystem;

public class HospitalRoom
{
    public int RoomNumber;
    public int Capacity;
    public List<Patient> Patients;

    public HospitalRoom(int roomNumber, int capacity)
    {
        this.RoomNumber = roomNumber;
        this.Capacity = capacity;
        this.Patients = new List<Patient>();
    }

    public void AddPatient(Patient patient)
    {
        if (Patients.Count < Capacity)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name} додан у палату №{RoomNumber}");
        }
        else
        {
            Console.WriteLine($"Палата №{RoomNumber} переповнена! Неможливо додати пацієнта.");
        }
    }
}