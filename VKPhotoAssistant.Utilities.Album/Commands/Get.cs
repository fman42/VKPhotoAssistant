using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Album.Options;
using VKPhotoAssistant.Utilities.Base;

namespace VKPhotoAssistant.Utilities.Album.Commands
{
    internal class Get : BaseCommandParser<GetTokenOptions>, ICommand
    {
        private VkApi API { get; set; } = new VkApi();

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args, IConfiguration configuration) => TryParseAsync(args,
            async (options) => {
                if (configuration["VKToken"] is null)
                {
                    Console.WriteLine("Token is null");
                    return;
                }

                API.Authorize(new ApiAuthParams()
                {
                    AccessToken = configuration["VKToken"]
                });

                if (options.AlbumId is null)
                    GetAlbums();
                else GetAlbumInfoById(options.AlbumId);
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
