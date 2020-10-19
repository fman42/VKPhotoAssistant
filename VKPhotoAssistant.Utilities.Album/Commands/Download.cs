using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Album.Options;
using VKPhotoAssistant.Utilities.Base;

namespace VKPhotoAssistant.Utilities.Album.Commands
{
    internal class Download : BaseCommandParser<DownloadOptions>, ICommand
    {
        private VkApi api { get; set; }

        private DownloadOptions DownloadOptions { get; set; }

        private WebClient Client { get; } = new WebClient();

        public Download()
        {
            api = new VkApi();
            api.Authorize(new ApiAuthParams()
            {
                AccessToken
                = "00eeec86d76c783b616c1f7659189411a4096ae110eef5bb3f9115007f12f3cbd389cf9dc0d585876a315"
            });
        }

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args,
            async (options) => {
                DownloadOptions = options;
                DownloadAlbum();
            }
        );

        private void DownloadAlbum()
        {
            string directory = $"{DownloadOptions.AlbumId}";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            PhotoGetParams getParams = new PhotoGetParams()
            {
                AlbumId = PhotoAlbumType.Id(DownloadOptions.AlbumId),
                Count = (ulong) DownloadOptions.Limit,
                Offset = (ulong) DownloadOptions.Offset
            };

            foreach (Photo photo in api.Photo.Get(getParams))
            {
                Console.WriteLine($"Файл {photo.Id} начал скачиваться в локальное хранилище");
                Client.DownloadFile(photo.Sizes.Last().Url, Path.Combine(directory, photo.Id + ".jpg"));
            }
        }
        #endregion
    }
}
