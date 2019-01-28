using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTest.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Access_Token { get; set; }
        public string Error_Description { get; set; }
        public DateTime Expire_Date { get; set; }

        public Token()
        {

        }

    }
}
