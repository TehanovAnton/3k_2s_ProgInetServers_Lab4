using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3_mvc.Models
{
    [Serializable]
    public class DictRecord
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }

        public DictRecord() { }

        public DictRecord(string lastName, string number)
        {
            Id = new DB().LastId() + 1;
            LastName = lastName;
            Number = number;
        }
    }
}