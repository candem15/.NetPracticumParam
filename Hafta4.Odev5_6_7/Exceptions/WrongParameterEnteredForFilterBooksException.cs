namespace Hafta4.Odev5_6_7.Exceptions
{
    public class WrongParameterEnteredForFilterBooksException : Exception
    {
        public WrongParameterEnteredForFilterBooksException() : base("Wrong parameter entered for filtering Books!")
        {
        }

        public WrongParameterEnteredForFilterBooksException(string? message) : base(message)
        {
        }

        public WrongParameterEnteredForFilterBooksException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
