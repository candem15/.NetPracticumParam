﻿namespace Hafta4.Odev5_6_7.Exceptions
{
    public class WrongUsernameEnteredException : Exception
    {
        public WrongUsernameEnteredException() : base("User with given username not exists! Please try again.")
        {
        }

        public WrongUsernameEnteredException(string? message) : base(message)
        {
        }

        public WrongUsernameEnteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
