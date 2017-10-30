using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RateCalcServices
{
    [Serializable]
    public class NotEnoughLoanOffersException : Exception
    {
        private string _actionFriendlyName;

        public string ActionFriendlyName
        {
            get => _actionFriendlyName;
            set => _actionFriendlyName = value;
        }

        public NotEnoughLoanOffersException()
        {
        }

        public NotEnoughLoanOffersException(string message) : base(message)
        {
        }

        public NotEnoughLoanOffersException(Action action, string message) : base(action + ": " + message)
        {
            ActionFriendlyName = action.ToString();
        }

        public NotEnoughLoanOffersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotEnoughLoanOffersException(Action action, Exception innerException) : base(action + ": " + innerException.Message, innerException)
        {
        }

        public NotEnoughLoanOffersException(Action action, string message, Exception innerException) : base(action + ": " + message, innerException)
        {
            _actionFriendlyName = action.ToString();
        }

        public NotEnoughLoanOffersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _actionFriendlyName = info.GetString("_actionFriendlyName");
        }

        public NotEnoughLoanOffersException(Action action, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _actionFriendlyName = action.ToString();
            _actionFriendlyName = info.GetString("_actionFriendlyName");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("_actionFriendlyName", _actionFriendlyName);
        }
    }
}