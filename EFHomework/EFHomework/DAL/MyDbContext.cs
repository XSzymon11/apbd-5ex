using EFHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace EFHomework.DAL;

public class SystemDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected SystemDbContext()
    {
    }

    public SystemDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Doctor INSERT data
        //Seed Doctor
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Daniel",
                LastName = "Danov",
                Email = "danov@gmail.com",
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Gosho",
                LastName = "Goshov",
                Email = "gosho@gmail.com",
            },
            new Doctor
            {
                IdDoctor = 3,
                FirstName = "Pesho",
                LastName = "Peshev",
                Email = "peshev@gmail.com",
            });
        #endregion
        
        #region Medicament INSERT data
        //Seed Medicament
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament
            {
                IdMedicament = 1,
                Name = "Ibuprofen",
                Description = "A non-steroidal anti-inflammatory drug (NSAID) used for pain relief and to reduce fever",
                Type = "Analgesic"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Paracetamol",
                Description = "A pain reliever and fever reducer with no significant anti-inflammatory properties",
                Type = "Analgesic"
            },
            new Medicament
            {
                IdMedicament = 3,
                Name = "Amoxicillin",
                Description = "A β-lactam antibiotic used to treat a variety of bacterial infections",
                Type = "Antibiotic"
            },
            new Medicament
            {
                IdMedicament = 4,
                Name = "Lisinopril",
                Description = " An ACE inhibitor used to treat high blood pressure and heart failure",
                Type = "Antihypertensive"
            },
            new Medicament
            {
                IdMedicament = 5,
                Name = "Omeprazole",
                Description = "A proton pump inhibitor used to treat acid reflux and stomach ulcers",
                Type = "Gastroprotective"
            },
            new Medicament
            {
                IdMedicament = 6,
                Name = "Metformin",
                Description = "An oral medication used to control blood sugar levels in people with type 2 diabetes",
                Type = "Antidiabetic"
            });
        #endregion
        
        #region Patient INSERT data
        //Seed Patient
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateOnly(1985, 5, 15)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Birthdate = new DateOnly(1990, 8, 22)
            },
            new Patient
            {
                IdPatient = 3,
                FirstName = "Michael",
                LastName = "Brown",
                Birthdate = new DateOnly(1975, 3, 10)
            },
            new Patient
            {
                IdPatient = 4,
                FirstName = "Emily",
                LastName = "Johnson",
                Birthdate = new DateOnly(2000, 12, 5)
            },
            new Patient
            {
                IdPatient = 5,
                FirstName = "David",
                LastName = "Lee",
                Birthdate = new DateOnly(1998, 7, 18)
            },
            new Patient
            {
                IdPatient = 6,
                FirstName = "Sophia",
                LastName = "Martinez",
                Birthdate = new DateOnly(1982, 1, 30)
            },
            new Patient
            {
                IdPatient = 7,
                FirstName = "Daniel",
                LastName = "Garcia",
                Birthdate = new DateOnly(1995, 4, 9)
            },
            new Patient
            {
                IdPatient = 8,
                FirstName = "Olivia",
                LastName = "Lopez",
                Birthdate = new DateOnly(1970, 9, 27)
            },
            new Patient
            {
                IdPatient = 9,
                FirstName = "William",
                LastName = "Wilson",
                Birthdate = new DateOnly(1965, 6, 12)
            },
            new Patient
            {
                IdPatient = 10,
                FirstName = "Emma",
                LastName = "Anderson",
                Birthdate = new DateOnly(2002, 11, 2)
            });
        #endregion
        
        #region Prescription INSERT data
        //Seed Prescription
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateOnly(2024, 5, 1),
                DueDate = new DateOnly(2024, 5, 15),
                IdDoctor = 1,
                IdPatient = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateOnly(2024, 5, 5),
                DueDate = new DateOnly(2024, 5, 20),
                IdDoctor = 2,
                IdPatient = 2
            },
            new Prescription
            {
                IdPrescription = 3,
                Date = new DateOnly(2024, 5, 10),
                DueDate = new DateOnly(2024, 6, 10),
                IdDoctor = 3,
                IdPatient = 3
            }
        );
        #endregion
        
        #region Prescription_Medicament INSERT data
        //Seed PrescriptionMedicament
        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 1,
                Dose = 200,
                Details = "Take one pill every 8 hours"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 2,
                Dose = 500,
                Details = "As needed for fever"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 2,
                IdMedicament = 3,
                Dose = 250,
                Details = "Three times daily"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 3,
                IdMedicament = 6,
                Dose = 1000,
                Details = "Take with food"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 3,
                IdMedicament = 5,
                Dose = 20,
                Details = "Before breakfast"
            }
        );
        #endregion
        
    }
}