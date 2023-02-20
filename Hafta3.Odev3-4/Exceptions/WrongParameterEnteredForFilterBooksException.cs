namespace Hafta3.Odev3_4.Exceptions
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
