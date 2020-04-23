using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientServiceHelper.Tests.Mock
{
    public class Person
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string FullName => $"{FirstName} {LastName}";

        public static Person GetPerson()
        {
            return new Person()
            {

            };
        }
    }
}
