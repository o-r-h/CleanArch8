namespace CleanArch.WebApi.Classes
{
	public class ErrorResponse
	{
		public string Title { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public int StatusCode { get; set; }
		public List<ValidationError> Errors { get; set; }

	}

	public class ValidationError
	{
		public string PropertyName { get; set; } =string.Empty;
		public string ErrorMessage { get; set; } = string.Empty;
	}
}
