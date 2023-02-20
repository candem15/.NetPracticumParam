﻿namespace Hafta3.Odev3_4.Exceptions
{
    public class BookNotExistsException : Exception
    {
        public BookNotExistsException(int id) : base($"Book with id: '{id}' not exists!")
        {
        }

        public BookNotExistsException(string? message) : base(message)
        {
        }

        public BookNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
