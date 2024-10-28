namespace CleanArch.WebApi.Middlewares
{
	public interface IExceptionHandler
	{
		ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken);
	}
}
