using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.BL.Exceptions
{
    public class ReviewIsNullException : Exception
    {
        public ReviewIsNullException()
        {
        }

        public ReviewIsNullException(string message) : base(message)
        {
        }

        public ReviewIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReviewIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
