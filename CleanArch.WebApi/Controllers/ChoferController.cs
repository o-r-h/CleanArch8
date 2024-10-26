using CleanArch.Application.Interfaces;
using CleanArch.Domain.DTOs.Choferes;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace CleanArch.WebApi.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ChoferController : ControllerBase
	{

		private readonly IChoferServices choferService;

		public ChoferController(IChoferServices choferService)
		{
			this.choferService = choferService;
		}


		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] ChoferDto choferDto)
		{
			var response = await choferService.Create(choferDto);
			return Ok(response);
		}


		//[HttpGet("Pagination")]
		//public async Task<IActionResult> PaginationAsync(SieveModel sieveModel)
		//{
		//	var pageExampleModel = await choferService.GetPagination(sieveModel);
		//	return Ok(pageExampleModel.ToList());
		//}

	}
}
