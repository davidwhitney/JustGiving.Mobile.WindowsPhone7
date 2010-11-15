using JustGiving.Api.Sdk;
using JustGiving.Api.Sdk.WindowsPhone7;

namespace JustGiving.App.Code
{
    public static class ApiClientFactory
    {
        public static JustGivingMobileClient Create(ApiContext context)
        {
            return new JustGivingMobileClient(new ClientConfiguration(context.ApiLocation, context.ApiKey, 1)
            {
                Username = context.Username,
                Password = context.Password,
                WireDataFormat = WireDataFormat.Xml
            });
        }
    }
}
