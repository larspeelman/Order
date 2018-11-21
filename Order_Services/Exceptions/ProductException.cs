using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Services.Exceptions
{
    class itemException : Exception
    {
        public itemException(string message) : base(message)
        {

        }
    }
}
