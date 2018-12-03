using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Models.Exceptions
{
    public class ForbbidenException : Exception
    {
        public ForbbidenException(string message) : base(message) { }
    }
}
