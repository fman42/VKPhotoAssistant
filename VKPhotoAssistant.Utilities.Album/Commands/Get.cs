using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Album.Options;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Storage;
using VKPhotoAssistant.Interfaces.Storage;

namespace VKPhotoAssistant.Utilities.Album.Commands
{
    internal class Get : BaseCommandParser<GetTokenOptions>, ICommand
    {
        private VkApi API { get; set; } = new VkApi();

        private JsonStorage Storage { get; }

        #region Init
        public Get() => Storage = JsonStorage.GetInstance();
        #endregion

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args,
            async (options) => {
                MainStorage storage = Storage.Read();

                if (!string.IsNullOrEmpty(storage.CurrentVKToken))
                {
                    API.Authorize(new ApiAuthParams()
                    {
                        AccessToken = storage.CurrentVKToken
                    });

                    if (options.AlbumId is null)
                        GetAlbums();
                    else GetAlbumInfoById(options.AlbumId);
                }
                else Console.WriteLine("token is null");
            }
        );

        private void GetAlbums()
        {
            foreach (PhotoAlbum album in API.Photo.GetAlbums(new PhotoGetAlbumsParams()))
                PrintAlbumToConsole(album);
        }

        private void GetAlbumInfoById(long? albumId)
        {
            PhotoGetAlbumsParams requestParams = new PhotoGetAlbumsParams() {
                AlbumIds = new long[] { (long) albumId }
            };

            foreach (PhotoAlbum album in API.Photo.GetAlbums(requestParams))
                PrintAlbumToConsole(album);
        }

        private void PrintAlbumToConsole(PhotoAlbum album)
        {
            Console.WriteLine($"Название альбома: {album.Title}");
            Console.WriteLine($"Количество фотографий: {album.Size}");
            Console.WriteLine($"Id: {album.Id}");
            Console.WriteLine($"Описание: {album.Description}");
            Console.WriteLine("-------------------------------------");
        }
        #endregion
    }
}
