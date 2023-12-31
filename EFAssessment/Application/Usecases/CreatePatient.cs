﻿using EFAssessment.Controllers.Dtos;
using EFAssessment.Domain.Contracts;
using EFAssessment.Domain.Entities;
using EFAssessment.Domain.Exceptions;
using EFAssessment.Infrastructure.Repositories;
using EFAssessment.Services;

namespace EFAssessment.Application.Usecases;

public class CreatePatient
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;

    public CreatePatient(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<List<Doctor>> GetAvailableSlots()
    {
        var slots = await _patientRepository.GetAvailableSlots();
        if (slots == null)
            return new List<Doctor> { };
        return new List<Doctor> { slots };
    }

    public async Task<List<Doctor>> CheckAvailability(Guid slotId)
    {
        var results = await _patientRepository.CheckAvailability(slotId);
        if (results == null)
            return new List<Doctor> { };
        return new List<Doctor> { results };
    }

    public async Task Execute(CreatePatientRequest request)
    {
        // PatientName is not empty
        if (!string.IsNullOrEmpty(request.PatientName))
        {
            throw new PatientNameEmptyException();
        }
        // Id used for booking must be unique
        var exists = _patientRepository.AvailabilityIsExist(request.Id);
        if (exists)
        {
            throw new AvailabilityAlreadyExistsException(request.Id);
        }
        // SlotId must be opened for reservation
        var checkResult = _patientRepository.CheckSlotAvailability(request.SlotId);
        if (!checkResult)
        {
            throw new ReservationNotOpenException(request.SlotId);
        }

        // Convert to Patient domain model
        var patient = Patient.CreateNew(request.PatientName, request.SlotId, request.PatientId);
        await _patientRepository.Add(patient);
    }

    public async Task UpdateReserved(Doctor doctor)
    {
        if (!string.IsNullOrEmpty(doctor.DoctorName))
        {
            throw new DoctorNameEmptyException();
        }
        // Id must be unique as a new slot
        var exists = _doctorRepository.AvailabilityIsExist(doctor.Id);
        if (exists)
        {
            throw new AvailabilityAlreadyExistsException(doctor.Id);
        }
        await _doctorRepository.UpdateReserved(doctor);
    }
   
}