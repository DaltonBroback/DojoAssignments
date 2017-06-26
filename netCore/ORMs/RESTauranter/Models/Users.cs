using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RESTauranter.Models
{
    public abstract class BaseEntity {}

    public class Users : BaseEntity
    {
        public Users(){
            reviews = new List<Reviews>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Reviews> reviews { get; set; }
    }
}