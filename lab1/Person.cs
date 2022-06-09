using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }  
        public Person(int personId, string personName)
        {
            PersonId = personId;
            PersonName = personName;
        }

        
    }
}
