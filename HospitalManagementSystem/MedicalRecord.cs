namespace HospitalManagementSystem;

public class MedicalRecord
{
    public Patient Patient;
    public Doctor Doctor;
    public DateTime Date;
    public string Description;

    public MedicalRecord(Patient patient, Doctor doctor, DateTime date, string description)
    {
        this.Patient = patient;
        this.Doctor = doctor;
        this.Date = date;
        this.Description = description;
    }
}