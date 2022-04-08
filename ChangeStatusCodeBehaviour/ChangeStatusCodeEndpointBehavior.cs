using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace CustomContentTypeBehaviour
{
	/// <summary>
	/// Source: https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/message-inspectors
	/// </summary>
	public class ChangeStatusCodeEndpointBehavior : IEndpointBehavior
	{
		private readonly int _statusCode;

		public ChangeStatusCodeEndpointBehavior(int statusCode)
		{
			_statusCode = statusCode;
		}
		public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint,
			System.ServiceModel.Dispatcher.ClientRuntime behavior)
		{
			behavior.ClientMessageInspectors.Add(new ChangeStatusCodeMessageInspector(_statusCode));
		}

		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint,
			System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
		{
		}

		public void Validate(ServiceEndpoint serviceEndpoint)
		{
		}
	}
}
