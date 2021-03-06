﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesAPI.Models
{
    public class StepIngredient
    {
        public int Id { get; set; }
             
        public string Quantity { get; set; }

        public int FKIngredientId { get; set; }
        public Ingredient FKIngredient { get; set; }

        public int FKStepId{ get; set; }
        public Step FKStep { get; set; }

    }
}