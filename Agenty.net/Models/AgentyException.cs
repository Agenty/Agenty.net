using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

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
        internal AgentyException(AgentyErrorResponse errorResponse, Exception inner) : base($"status: {errorResponse.Status}, code: {errorResponse.Code} name: {errorResponse.Name} messsage: {errorResponse.Message}", inner)
        {
            Status = errorResponse.Status;
            Code = errorResponse.Code;
            Name = errorResponse.Name;
        }

        public string Status { get; private set; }
        public int? Code { get; private set; }
        public string Name { get; private set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected AgentyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Status = info.GetString("Status");
            Code = (int?)info.GetValue("Code", typeof(int?));
            Name = info.GetString("Name");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info = info ?? throw new ArgumentNullException(nameof(info));

            info.AddValue("Status", Status);
            info.AddValue("Name", Name);
            info.AddValue("Code", Code, typeof(int?));

            base.GetObjectData(info, context);
        }
    }
}
