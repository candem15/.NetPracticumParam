namespace Hafta4.Odev5_6_7.Exceptions
{
    public class GenreToDeleteNotExistsException : Exception
    {
        public GenreToDeleteNotExistsException(int id) : base($"Genre to delete with id: '{id}' not exists!")
        {
        }

        public GenreToDeleteNotExistsException(string? message) : base(message)
        {
        }

        public GenreToDeleteNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
