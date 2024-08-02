﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<ProductIngredient>? ProductIngredients { get; set; }
    }
}
