using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class UpdateMovie
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public float Score { get; set; }
    }
}