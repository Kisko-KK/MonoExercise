using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class MovieView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public MovieView(int id, string title, string descritpion)
        {
            Id = id;
            Title = title;
            Description = descritpion;
        }
    }
}