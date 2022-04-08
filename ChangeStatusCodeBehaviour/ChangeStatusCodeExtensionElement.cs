using System;
using System.ComponentModel;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace CustomContentTypeBehaviour

{
	public class ChangeStatusCodeExtensionElement : BehaviorExtensionElement
	{
		[Description("The target's system ContentType, e.g. application/xml")]
		[ConfigurationProperty("StatusCode", IsRequired = true, DefaultValue = 200)]
		public int StatusCode
		{
			get { return (int)base["StatusCode"]; }
			set { base["StatusCode"] = value; }
		}
		
		protected override ConfigurationPropertyCollection Properties =>
			new ConfigurationPropertyCollection 
			{
				new ConfigurationProperty(
					"StatusCode",
					typeof(int), 
					200, 
					null, 
					null,
					ConfigurationPropertyOptions.IsRequired
				)
			};

		public ChangeStatusCodeExtensionElement()
		{
		}

		public ChangeStatusCodeExtensionElement(int statusCode)
		{
			StatusCode = statusCode;
		}

		protected override object CreateBehavior()
		{
			return new ChangeStatusCodeEndpointBehavior(StatusCode);
		}

		public override Type BehaviorType => typeof(ChangeStatusCodeEndpointBehavior);
	}
}