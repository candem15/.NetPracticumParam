namespace Hafta4.Odev5_6_7.Exceptions
{
    public class BookToDeleteNotExistsException : Exception
    {
        public BookToDeleteNotExistsException(int id) : base($"Book to delete with id: '{id}' not exists!")
        {
        }

        public BookToDeleteNotExistsException(string? message) : base(message)
        {
        }

        public BookToDeleteNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
