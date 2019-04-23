using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenty.net.Models
{
    [Serializable]
    public class AgentyException : Exception
    {
        public AgentyException()
        {
        }
        public AgentyException(string message) : base(message)
        {
        }

        public AgentyException(string message, Exception inner) : base(message, inner)
        {
        }
        internal AgentyException(AgentyErrorResponse errorResponse, Exception inner)
    }
}
