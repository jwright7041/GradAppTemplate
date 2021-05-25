using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.ApiModels
{
    public static class MediaMappingExtentions
    {
        public static MediaModel ToApiModel(this Media media)
        {
            return new MediaModel
            {
                Id = media.Id,
                Name = media.Name,
                Type = media.Type,
                Status = media.Status,
                UserId = media.UserId
            };
        }

        public static Media ToDomainModel(this MediaModel media)
        {
            return new Media
            {
                Id = media.Id,
                Name = media.Name,
                Type = media.Type,
                Status = media.Status,
                UserId = media.UserId,
            };
        }

        public static IEnumerable<MediaModel> ToApiModels(this IEnumerable<Media> medias)
        {
            return medias.Select(a => a.ToApiModel());
        }
        
        public static IEnumerable<Media> ToDomainModels(this IEnumerable<MediaModel> mediaModels)
        {
            return mediaModels.Select(a => a.ToDomainModel());
        } 
    }
}
