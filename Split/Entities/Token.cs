using System;
using System.Collections.Generic;
using System.Text;
using Split.Services;

namespace Split.Entities
{
    class Token
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_in { get; set; }
    }
}
