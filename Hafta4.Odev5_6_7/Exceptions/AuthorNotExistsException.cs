namespace Hafta4.Odev5_6_7.Exceptions
{
    public class AuthorNotExistsException : Exception
    {
        public AuthorNotExistsException(int id) : base($"Author with id: '{id}' not exists!")
        {
        }

        public AuthorNotExistsException(string? message) : base(message)
        {
        }

        public AuthorNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
