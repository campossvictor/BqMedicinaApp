using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;
using Microsoft.AspNetCore.Mvc;

namespace BqMedicinaApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatient()
    {
        var patients = await _patientRepository.GetAll();

        if (patients is null)
        {
            return NotFound("There is no registered records");
        }

        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatientById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Parameter 'id' is null");
        }
        
        var patient = await _patientRepository.GetById(u => u.Id == id);
        
        if (patient is null)
        {
            return NotFound("Patient isn't registered");
        }

        return Ok(patient);
    }

    [HttpPost("NewPatient")]

    public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
    {
        if (patient is null)
        {
            return BadRequest("Inser a valid information about the patient");
        }

        var patientCreated = await _patientRepository.CreateEntity(patient);

        return Ok(patientCreated);
    }

    [HttpPut("ChangePatient")]

    public async Task<ActionResult<Patient>> UpdatePatient(int id, Patient patient)
    {
        if (id <= 0)
        {
            return BadRequest("Insert a id that you wish change");
        }
        
        if (patient is null)
        {
            return BadRequest("Entered the changes about the patient");
        }
        
        var changedPatient = await _patientRepository.GetById(u => u.Id == id);

        if (changedPatient is null)
        {
            return NotFound($"There not is any user with this id {id}");
        }
        
        if (id != patient.Id)
        {
            return BadRequest("The patient that you wish change is not the same user that you reported.");
        }
        
        await _patientRepository.UpdateEntity(patient);

        return Ok(patient);
    }

    [HttpDelete("DeletePatient")]

    public async Task<ActionResult<Patient>> DeletePatient(Patient patient)
    {
        if (patient is null)
        {
            return BadRequest("Enter patient details ");
        }

        var deletedpatient = await _patientRepository.GetById(u => u.Id == patient.Id);

        if (deletedpatient is null)
        {
            return NotFound($"There not is any user registred");
        }
        
        _patientRepository.DeleteEntity(patient);

        return Ok(patient);
    }
}