using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class Movie
    {
        public Movie(int id, string title, string description, double score) { 
            Id = id; Title = title; Description = description; Score = score;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
    }
}