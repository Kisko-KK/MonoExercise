using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class Hall
    {
        public Hall(Guid id, string name, int numOfSeats) { 
            Id = id;
            Name = name;
            NumOfSeats = numOfSeats;
        }
        public Hall() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumOfSeats { get; set; }

    }
}