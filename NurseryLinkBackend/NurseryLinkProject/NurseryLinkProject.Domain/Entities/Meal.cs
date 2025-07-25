using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class Meal: Activity
    {
        public MealType MealType { get; set; } 
        public MealStatus MealStatus { get; set; } 
    }

    public enum MealType
    {
        Breakfast,
        Lunch,
        Snack,
        Dinner,
        Other
    }

    public enum MealStatus
    {
        Eaten,
        NotEaten,
        Partial,
        Other
    }
}
