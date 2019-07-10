using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.Exceptions
{
    class TableOutputNotSupported :Exception
    {
        public TableOutputNotSupported(string message) : base(message)
        {

        }
    }
}
