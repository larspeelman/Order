using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Services.Exceptions
{
    class ProductException : Exception
    {
        public ProductException(string message) : base(message)
        {

        }
    }
}
