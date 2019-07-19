using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.Exceptions
{
    class TableOutputNotSupportedException :Exception
    {
        public TableOutputNotSupportedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
