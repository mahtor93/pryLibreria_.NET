﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pryBookstore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }


        public override string ToString()
        {
            return Title;
        }

    }
}
