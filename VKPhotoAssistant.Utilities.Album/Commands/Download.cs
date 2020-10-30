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
using VkNet.Utils;
using VKPhotoAssistant.Interfaces.Storage;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Storage;
using VKPhotoAssistant.Utilities.Album.Options;
using VKPhotoAssistant.Utilities.Base;

namespace VKPhotoAssistant.Utilities.Album.Commands
{
    internal class Download : BaseCommandParser<DownloadOptions>, ICommand
    {
        #region Vars
        private VkApi API { get; set; } = new VkApi();

        private DownloadOptions DownloadOptions { get; set; }

        private WebClient Client { get; } = new WebClient();

        private MainStorage Storage { get; } = JsonStorage.GetInstance().Read();
        #endregion

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args, Action);

        private Task Action(DownloadOptions options)
        {
            if (string.IsNullOrEmpty(Storage.CurrentVKToken))
            {
                Console.WriteLine("Токен не установлен");
                return Task.CompletedTask;
            }

            API.Authorize(new ApiAuthParams()
            {
                AccessToken = Storage.CurrentVKToken
            });

            DownloadOptions = options;
            DownloadAlbum();

            return Task.CompletedTask;
        }

        private void DownloadAlbum()
        {
            string directory = TryGetDownloadedFolderName(DownloadOptions.AlbumId);
            
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

        private string TryGetDownloadedFolderName(long id)
        {
            VkCollection<PhotoAlbum> album = API.Photo.GetAlbums(new PhotoGetAlbumsParams() {
                AlbumIds = new long[] { DownloadOptions.AlbumId }
            });
            string directory = album.First().Title;

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return directory;
        }
        #endregion
    }
}
