using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Recipes
{
    internal class RecipeSteps
    {
        public int ID { get; set; }
        public int StepNum { get; set; }
        public string Step { get; set; }
        public int RecipeID { get; set; }
        public string StepName { get; set; }

    }
}
