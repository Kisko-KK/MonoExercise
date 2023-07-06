using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; }
    }
}