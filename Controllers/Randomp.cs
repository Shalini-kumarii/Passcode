using System;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using myrand = Random_passcode.Models.Randomp;

namespace Randomp.Controllers     //be sure to use your own project's namespace!
{
    public class Randomp : Controller   //remember inheritance??
    {
        static int MAX = 36;

        [HttpGet("")]      // Both lines can be written in one line
        public IActionResult Index()
        {
            myrand randp = new myrand();
            if(HttpContext.Session.GetString("Passcode")!= null)
            {
                randp.Passcode = HttpContext.Session.GetString("Passcode");
                return View("Index",randp);
            }
            // var model = new Dojo();
            //     model.Location = "Bellevue";
            return View("Index");
        }

        [HttpPost]
        [Route("")]
        public IActionResult Result(myrand randp)
        {
           
            int n = 14;
            randp.Passcode = printRandomString(n);
            HttpContext.Session.SetString("Passcode",randp.Passcode);
            return View("Index",randp);
        }



        // Returns a String of random alphabets of
        // length n.
        static string printRandomString(int n)
        {
            char[] alphanum = { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                        'h', 'i', 'j', 'k', 'l', 'm', 'n',
                        'o', 'p', 'q', 'r', 's', 't', 'u',
                        'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Random random = new Random();
            string res = "";
            for (int i = 0; i < n; i++)
                res = res + alphanum[(int)(random.Next(0, MAX))];

            return res;
        }


    }
}