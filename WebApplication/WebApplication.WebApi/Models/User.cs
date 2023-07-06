using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}