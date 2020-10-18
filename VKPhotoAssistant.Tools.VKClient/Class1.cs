using VKPhotoAssistant.Interfaces;
using VkNet;
using VkNet.Model;

namespace VKPhotoAssistant.Tools.VKClient
{
    public class VKClient
    {
        public VkApi Client { private set; get; }

        public VKClient(string accessToken)
        {
            Client = new VkApi();
            Client.Authorize(new ApiAuthParams()
            {
                AccessToken = accessToken
            });
        }
    }
}
