namespace CleanArch.Domain.Exceptions
{
	public abstract class BaseException : Exception
	{
		public string Title { get; private set; }
		public int StatusCode { get; private set; }

		protected BaseException(string message, string title, int statusCode)
			: base(message)
		{
			Title = title;
			StatusCode = statusCode;
		}
	}
}
