namespace Hafta4.Odev5_6_7.Exceptions
{
    public class GenreNotExistsException : Exception
    {
        public GenreNotExistsException(int id) : base($"Genre with id: '{id}' not exists!")
        {
        }

        public GenreNotExistsException(string? message) : base(message)
        {
        }

        public GenreNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
