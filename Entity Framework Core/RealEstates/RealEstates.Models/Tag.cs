﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        public int Id { get; set; }

        [Required]
        public string TagProperty { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
