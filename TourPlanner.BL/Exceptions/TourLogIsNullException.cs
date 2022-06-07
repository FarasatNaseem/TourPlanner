using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.BL.Exceptions
{
    public class TourLogIsNullException : Exception
    {
        public TourLogIsNullException()
        {
        }

        public TourLogIsNullException(string message) : base(message)
        {
        }

        public TourLogIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TourLogIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
