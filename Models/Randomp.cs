using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Random_passcode.Models
{
    public class Randomp
    {
         
        [Display(Name = "Random Passcode:")] 
        public string Passcode { get; set; }


    public Randomp()
        {

         }
    }

}