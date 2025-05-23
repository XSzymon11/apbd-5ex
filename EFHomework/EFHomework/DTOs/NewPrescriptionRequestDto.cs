namespace EFHomework.DTOs;

public class NewPrescriptionRequestDto
{
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }

    public int IdDoctor { get; set; }

    public PatientDto Patient { get; set; }

    public List<PrescriptionMedicamentDto> Medicaments { get; set; }
}

public class PatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
}

public class PrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}