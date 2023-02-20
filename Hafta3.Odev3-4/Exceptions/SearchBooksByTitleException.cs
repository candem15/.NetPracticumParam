namespace Hafta3.Odev3_4.Exceptions
{
    public class SearchBooksByTitleException : Exception
    {
        public SearchBooksByTitleException(string title, string? message) : base($"There is no Book that contains in title: '{title}'")
        {
        }

        public SearchBooksByTitleException(string? message) : base(message)
        {
        }

        public SearchBooksByTitleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
