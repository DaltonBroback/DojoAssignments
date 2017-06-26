using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RESTauranter.Models
{
    public class Restaurants : BaseEntity
    {
        public Restaurants(){
            reviews = new List<Reviews>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Reviews> reviews { get; set; }
    }
}