using JustGiving.Api.Sdk.WindowsPhone7;

namespace JustGiving.App.Code
{
    public static class ApplicationContext
    {
        public static ApiContext ApiContext { get; private set; }
        public static JustGivingMobileClient Client { get; set; }

        public static void SetApiContext(string username, string password)
        {
            ApiContext = new ApiContext {Username = username, Password = password};
            Client = ApiClientFactory.Create(ApiContext);
        }
    }
}
