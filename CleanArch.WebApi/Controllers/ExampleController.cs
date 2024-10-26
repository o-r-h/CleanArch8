using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace CleanArch.WebApi.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ExampleController : ControllerBase
	{

		private readonly IExampleService exampleService;

		public ExampleController(IExampleService exampleService)
		{
			this.exampleService = exampleService;
		}



		[HttpGet("Pagination")]
		public IActionResult Pagination(SieveModel sieveModel)
		{
			var pageExampleModel = exampleService.GetPagination(sieveModel);
			return Ok(pageExampleModel.ToList());
		}


		[HttpGet("GetAll")]
		public  IActionResult GetAll()
		{
			var response =  exampleService.GetAll();
			return Ok(response);
		}


		#region CRUD

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] ExampleModel example)
		{
			var response = await exampleService.CreateAsync(example);
			return Ok(response);
		}


		[HttpPost("Update")]
		public async Task<IActionResult> Update(long id, [FromBody] ExampleModel example)
		{
			await exampleService.UpdateAsync(id, example);
			return Ok();
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetByIdAsync(long? id)
		{
			var response = await exampleService.GetExample(id);
			if (response == null){
				return NotFound();
			}
			return Ok(response);
		}



		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(long idExample)
		{
			//await exampleService.DeleteAsync(idExample);
			return Ok();
		}



		#endregion
	}
}
