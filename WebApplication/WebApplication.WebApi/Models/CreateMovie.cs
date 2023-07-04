using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class CreateMovie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
    }
}