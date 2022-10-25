using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevSundt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BmiController : ControllerBase
{
    private readonly IBmiGetAllQuery _bmiGetAllQuery;
    private readonly ICreateBmiCommand _createBmiCommand;
    private readonly IEditBmiCommand _editBmiCommand;

    public BmiController(IBmiGetAllQuery bmiGetAllQuery, ICreateBmiCommand createBmiCommand,
        IEditBmiCommand editBmiCommand)
    {
        _bmiGetAllQuery = bmiGetAllQuery;
        _createBmiCommand = createBmiCommand;
        _editBmiCommand = editBmiCommand;
    }

    // GET api/<BmiController>/5
    [HttpGet("{userId}")]
    public IEnumerable<BmiQueryResultDto> Get(string userId)
    {
        return _bmiGetAllQuery.GetAll(userId);
    }

    // POST api/<BmiController>
    [HttpPost]
    public void Post([FromBody] BmiCreateRequestDto request)
    {
        _createBmiCommand.Create(request);
    }

    // PUT api/<BmiController>/5
    [HttpPut]
    public void Put([FromBody] BmiEditRequestDto request)
    {
        _editBmiCommand.Edit(request);
    }
}