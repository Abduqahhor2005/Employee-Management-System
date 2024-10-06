using Exam9.Entity;
using Exam9.Service;
using Microsoft.AspNetCore.Mvc;

namespace Exam9.Controller;
[ApiController]
[Route("api/employees")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeeAsync()
    {
        return Ok(await employeeService.GetAllEmployeesAsync());
    }
    [HttpGet("{isActive:bool}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesByActive(bool isActive)
    {
        return Ok(await employeeService.GetAllEmployeesByActive(isActive));
    }
    [HttpGet("{departmentName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesByDepartmentName(string departmentName)
    {
        return Ok(await employeeService.GetAllEmployeesByDepartmentName(departmentName));
    }
    [HttpGet("salary-statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesBySalary()
    {
        return Ok(await employeeService.GetAllEmployeesBySalary());
    }
    [HttpGet("birthdays/startDate={startDate}&endDate={endDate}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesByBirthdays(DateTime startDate, DateTime endDate)
    {
        return Ok(await employeeService.GetAllEmployeesByBirthdays(startDate,endDate));
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Employee?>> GetEmployeeByIdAsync([FromRoute]Guid id)
    {
        Employee? employee = await employeeService.GetEmployeeByIdAsync(id);
        if (employee == null) return NotFound();
        return Ok(await employeeService.GetEmployeeByIdAsync(id));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateAsync([FromBody]Employee? employee)
    {
        if (employee == null) return BadRequest();
        return Ok(await employeeService.CreateAsync(employee));
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateAsync([FromBody]Employee? employee)
    {
        if (employee == null) return BadRequest();
        return Ok(await employeeService.UpdateAsync(employee));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        bool res = await employeeService.DeleteAsync(id);
        if (res==false) return NotFound();
        return Ok(res);
    }
}