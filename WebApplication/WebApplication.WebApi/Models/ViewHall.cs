using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.WebApi.Models
{
    public class ViewHall
    {
        public ViewHall(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public ViewHall() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}