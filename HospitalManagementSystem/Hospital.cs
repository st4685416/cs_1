namespace HospitalManagementSystem;

public class Hospital
{
    public List<Doctor> Doctors;
    public List<Patient> Patients;
    public List<HospitalRoom> Rooms;
    public List<MedicalRecord> Records;

    public Hospital()
    {
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
        Rooms = new List<HospitalRoom>();
        Records = new List<MedicalRecord>();
    }

    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
        Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
    }

    public void RegisterPatient(Patient patient)
    {
        Patients.Add(patient);
        Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
    }

    public void CreateRoom(HospitalRoom room)
    {
        Rooms.Add(room);
        Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
    }

    public void HospitalizePatient(int patientId, int roomNumber)
    {
        foreach (Patient patient in Patients)
        {
            if (patient.Id == patientId)
            {
                foreach (HospitalRoom room in Rooms)
                {
                    if (room.RoomNumber == roomNumber)
                    {
                        room.AddPatient(patient);
                        return;
                    }
                }
                Console.WriteLine($"Палата №{roomNumber} не знайдена!");
                return;
            }
        }
        Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
    }

    public void AddMedicalRecord(MedicalRecord record)
    {
        Records.Add(record);
        Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
    }
    
    public List<MedicalRecord> GetPatientHistory(int patientId)
    {
        List<MedicalRecord> records = new List<MedicalRecord>();
            
        foreach (MedicalRecord record in Records)
        {
            if (record.Patient.Id == patientId)
            {
                records.Add(record); 
            }
        }
        return records;
    }

    public string GetStatistics()
    {
        int totalPatientsInRooms=0;
        
        foreach (HospitalRoom room in Rooms)
        {
            totalPatientsInRooms += room.Patients.Count;
        }
        return $"\n=== СТАТИСТИКА ЛІКАРНІ ===\n\nКількість лікарів: {Doctors.Count}\n\nКількість зареєстрованих пацієнтів: {Patients.Count}\n\nКількість палат: {Rooms.Count}\n\nКількість пацієнтів у палатах: {totalPatientsInRooms}\n\nКількість медичних записів: {Records.Count}\n\n";
    }

}