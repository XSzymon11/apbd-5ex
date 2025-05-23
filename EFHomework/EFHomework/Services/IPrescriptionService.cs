using EFHomework.DTOs;

namespace EFHomework.Services;

public interface IPrescriptionService
{
    Task AddPrescriptionAsync(NewPrescriptionRequestDto request);
    Task<PatientDetailsResponseDto> GetPatientAsync(int id);
}