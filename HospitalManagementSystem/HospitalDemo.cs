namespace HospitalManagementSystem;

public class HospitalDemo
{
    public void Run()
    {   
        Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");
        
        Hospital hospital1= new Hospital();
        
        // Додавання лікарів
        hospital1.AddDoctor(new Doctor(1,"Doctor1","specialization1"));
        hospital1.AddDoctor(new Doctor(2,"Doctor2","specialization2"));
        hospital1.AddDoctor(new Doctor(3,"Doctor3","specialization3"));
        
        // Реєстрація пацієнтів
        hospital1.RegisterPatient(new Patient(1,"Patient1",1));
        hospital1.RegisterPatient(new Patient(2,"Patient2",2));
        hospital1.RegisterPatient(new Patient(3,"Patient3",3));
        hospital1.RegisterPatient(new Patient(4,"Patient4",4));
        
        // Створення палат
        hospital1.CreateRoom(new HospitalRoom(1, 1));
        hospital1.CreateRoom(new HospitalRoom(2, 15));
        hospital1.CreateRoom(new HospitalRoom(3, 3));
        
        // Госпіталізація
        hospital1.HospitalizePatient(1,1);
        hospital1.HospitalizePatient(2,3);
        hospital1.HospitalizePatient(3,3);
        hospital1.HospitalizePatient(4,3);
        
        // Медичні записи
        hospital1.AddMedicalRecord(new MedicalRecord(hospital1.Patients[0],hospital1.Doctors[0], new DateTime(2001,1,1), "description1"));
        hospital1.AddMedicalRecord(new MedicalRecord(hospital1.Patients[1],hospital1.Doctors[1], new DateTime(2002,2,2), "description2"));
        hospital1.AddMedicalRecord(new MedicalRecord(hospital1.Patients[2],hospital1.Doctors[2], new DateTime(2003,3,3), "description3"));
        hospital1.AddMedicalRecord(new MedicalRecord(hospital1.Patients[1],hospital1.Doctors[2], new DateTime(2004,4,4), "description4"));

        // Історія пацієнта
        Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
        var history = hospital1.GetPatientHistory(2);
        foreach (var record in history)
        {
            Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
            Console.WriteLine($"  Лікар: {record.Doctor.Name}");
            Console.WriteLine($"  Опис: {record.Description}\n");
        }
    
        // Статистика
        Console.WriteLine(hospital1.GetStatistics());

        
    }   
}