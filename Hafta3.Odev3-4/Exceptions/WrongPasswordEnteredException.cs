﻿namespace Hafta3.Odev3_4.Exceptions
{
    public class WrongPasswordEnteredException : Exception
    {
        public WrongPasswordEnteredException() : base("Wrong password entered! Please retry to login with correct one.")
        {
        }

        public WrongPasswordEnteredException(string? message) : base(message)
        {
        }

        public WrongPasswordEnteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
