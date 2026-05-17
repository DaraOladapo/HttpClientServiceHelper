using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientServiceHelper.Tests.Mock
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public static Person GetPerson()
        {
            return new Person()
            {
                FirstName = "Dara",
                LastName = "Oladapo"
            };
        }
    }
}
