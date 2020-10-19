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
using Microsoft.Extensions.Configuration;

namespace VKPhotoAssistant.Utilities.Album.Commands
{
    internal class Download : BaseCommandParser<DownloadOptions>, ICommand
    {
        private VkApi API { get; set; } = new VkApi();

        private DownloadOptions DownloadOptions { get; set; }

        private WebClient Client { get; } = new WebClient();

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args, IConfiguration configuration) => TryParseAsync(args,
            async (options) => {
                if (configuration["VKToken"].ToString().Length == 0)
                {
                    Console.WriteLine("Token is null");
                    return;
                }

                API.Authorize(new ApiAuthParams()
                {
                    AccessToken = "4ab17849f23e71e1c478be84cd07a2f4dfccec2be0db015dd5d0390442e5a966262528143692fb3b0af8d"
                });

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

            foreach (Photo photo in API.Photo.Get(getParams))
            {
                Console.WriteLine($"Файл {photo.Id} начал скачиваться в локальное хранилище");
                Client.DownloadFile(photo.Sizes.Last().Url, Path.Combine(directory, photo.Id + ".jpg"));
            }
        }
        #endregion
    }
}
