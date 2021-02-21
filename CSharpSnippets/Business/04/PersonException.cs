using System;

namespace CSharpSnippets.Business._04
{
    public class PersonException : Exception
    {
        public PersonException() : base() { }

        public PersonException(string message) : base(message) { }

        public PersonException(
          string message, Exception innerException)
          : base(message, innerException) { }
    }
}
