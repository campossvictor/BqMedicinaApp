using System.Net;
using BqMedicinaApp.API.Models;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Specific;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BqMedicinaApp.API.Controllers;

[ApiController]
[Route("api/v1/Doctors")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorController(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
    {
        var users = await _doctorRepository.GetAll();
        var doctors = users.Where(u => u.IsDoctor);
        if (doctors.Count() == 0)
        {
            return NotFound("");
        }

        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctorById(int id)
    {
        var doctor = await _doctorRepository.GetById(u => u.Id == id);

        if (doctor is null)
        {
            return NotFound("");
        }

        return Ok(doctor);
    }

    [HttpPost("NewDoctor")]
    public async Task<ActionResult<Doctor>> CreateDoctor(Doctor doctor)
    {
        var NewDoctor = await _doctorRepository.CreateEntity(doctor);

        return Ok(NewDoctor);

    }

    [HttpPut("ChangeDoctor")]
    public async Task<ActionResult<Doctor>> UpdateDoctor(int id, Doctor doctor)
    {
        if (id <= 0)
        {
            return BadRequest("Insert a id that you wish change");
        }

        if (doctor is null)
        {
            return BadRequest("Entered the changes about the doctor");
        }

        var changeDoctor = await _doctorRepository.GetById(u => u.Id == id && u.IsDoctor);

        if (changeDoctor is null)
        {
            return NotFound($"There not is any user with this id {id}");
        }

        if (id != doctor.Id)
        {
            return BadRequest("The doctor that you wish change is not the same user that you reported.");
        }

        await _doctorRepository.UpdateEntity(doctor);

        return Ok(doctor);
    }

    [HttpDelete("DeleteDoctor")]
    public async Task<ActionResult<Doctor>> DeleteDoctorById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Id Doctor");
        }

        var deletedDoctor = await _doctorRepository.GetById(u => u.Id == id && u.IsDoctor);

        if (deletedDoctor is null)
        {
            return NotFound("There isn't user with this id");
        }

        _doctorRepository.DeleteEntity(deletedDoctor);

        return Ok(deletedDoctor);

    }
}