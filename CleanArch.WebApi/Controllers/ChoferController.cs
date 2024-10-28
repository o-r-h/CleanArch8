using CleanArch.Application.Interfaces;
using CleanArch.Domain.DTOs.Choferes;
using CleanArch.WebApi.Classes;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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


		//[HttpPost("Create")]
		//public async Task<IActionResult> Create([FromBody] ChoferDto choferDto)
		//{
		//	try
		//	{
		//		var response = await choferService.Create(choferDto);
		//		return Ok(response);
		//	}
		//	catch (ValidationException ex)
		//	{
		//		var errorResponse = new ErrorResponse
		//		{
		//			Title = "Validation Error",
		//			Message = string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)),
		//			StatusCode = 400
		//		};
		//		return BadRequest(errorResponse);
		//	}

		//	catch (Exception ex)
		//	{
		//		// Respuesta genérica para errores no controlados
		//		var errorResponse = new ErrorResponse
		//		{
		//			Title = "An error occurred",
		//			Message = ex.Message,
		//			StatusCode = 500
		//		};
		//		return StatusCode(500, errorResponse);
		//	}
		//}


		//[HttpGet("Pagination")]
		//public async Task<IActionResult> PaginationAsync(SieveModel sieveModel)
		//{
		//	var pageExampleModel = await choferService.GetPagination(sieveModel);
		//	return Ok(pageExampleModel.ToList());
		//}

	}
}
