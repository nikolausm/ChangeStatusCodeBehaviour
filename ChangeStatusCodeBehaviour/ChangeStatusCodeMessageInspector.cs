using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace CustomContentTypeBehaviour
{
	public class ChangeStatusCodeMessageInspector : IClientMessageInspector
	{
		private readonly int _statusCode;

		public ChangeStatusCodeMessageInspector(int statusCode)
		{
			_statusCode = statusCode;
		}
		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
			if (reply.Properties.TryGetValue(HttpResponseMessageProperty.Name, out var message))
			{
				var httpRequestMessage = (HttpResponseMessageProperty)message;
				httpRequestMessage.StatusCode = (HttpStatusCode) _statusCode;
			}
			else
			{
				var httpRequestMessage = new HttpResponseMessageProperty();
				httpRequestMessage.StatusCode = (HttpStatusCode) _statusCode;
				reply.Properties.Add(HttpResponseMessageProperty.Name, httpRequestMessage);
			}
		}

		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			return null;
		}
	}
}


