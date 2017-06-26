using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace netCoreBeltExam.Models
{
    public class Friendship : BaseEntity
    {
        public User user1 { get; set; }
        public User user2 { get; set; }

        public int status { get; set; }

        public User action_user { get; set;}
    }
}