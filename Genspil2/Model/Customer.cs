using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Genspil2.Model.Filehandlers;

namespace Genspil2.Model
{
    internal class Customer
    {

        public Customer(string name, string tlf, string email, int id)
        {
            Name = name;
            Tlf = tlf;
            Email = email;
            Id = id;
        }
        public string Name { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        public int Id { get; }
    }

}




