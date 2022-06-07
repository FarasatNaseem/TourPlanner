using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.BL.Exceptions
{
    public class TourIsNullException : Exception
    {
        public TourIsNullException()
        {
        }

        public TourIsNullException(string message) : base(message)
        {
        }

        public TourIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TourIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
