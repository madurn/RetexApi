using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetexApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CardName { get; set; }
        public double CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CVV { get; set; }
        public string CardAddress { get; set; }
        public string CardCity { get; set; }
        public string CardState { get; set; }
        public int CardZipCode { get; set; }
        public string CardPhone { get; set; }
    }
}
