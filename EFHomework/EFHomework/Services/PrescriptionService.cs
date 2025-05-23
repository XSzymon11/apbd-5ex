using EFHomework.DAL;
using EFHomework.DTOs;
using EFHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace EFHomework.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly SystemDbContext _context;

    public PrescriptionService(SystemDbContext context)
    {
        _context = context;
    }

    public async Task AddPrescriptionAsync(NewPrescriptionRequestDto request)
    {
        if (request.Medicaments.Count > 10)
            throw new ArgumentException("Cannot add more than 10 meds");

        if (request.DueDate < request.Date)
            throw new ArgumentException("Due date cannot be earlier than start date");

        var doctor = await _context.Doctors.FindAsync(request.IdDoctor);
        if (doctor == null)
            throw new ArgumentException("Doc not found.");

        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.FirstName == request.Patient.FirstName &&
                                      p.LastName == request.Patient.LastName &&
                                      p.Birthdate == request.Patient.Birthdate);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdDoctor = doctor.IdDoctor,
            IdPatient = patient.IdPatient
        };
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        foreach (var med in request.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(med.IdMedicament);
            if (medicament == null)
                throw new ArgumentException($"Medicament with id {med.IdMedicament} not found.");

            _context.PrescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medicament.IdMedicament,
                Dose = med.Dose,
                Details = med.Details
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<PatientDetailsResponseDto> GetPatientAsync(int id)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == id);

        if (patient == null) throw new KeyNotFoundException("Patient not found.");

        return new PatientDetailsResponseDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(p => p.DueDate)
                .Select(p => new PrescriptionDto
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDto
                    {
                        IdDoctor = p.Doctor.IdDoctor,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                        Email = p.Doctor.Email
                    },
                    Medicaments = p.PrescriptionMedicaments
                        .Select(pm => new MedicamentDto
                        {
                            Name = pm.Medicament.Name,
                            Description = pm.Medicament.Description,
                            Type = pm.Medicament.Type,
                            Dose = pm.Dose,
                            Details = pm.Details
                        }).ToList()
                }).ToList()
        };
    }
}