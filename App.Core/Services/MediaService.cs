using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Models;

namespace App.Core.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository media)
        {
            _mediaRepository = media;
        }

        public Media Add(Media media)
        {
            return _mediaRepository.Add(media);
        }

        public Media Get(int id)
        {
            return _mediaRepository.Get(id);
        }

        public IEnumerable<Media> GetAll()
        {
            return _mediaRepository.GetAll();
        }

        public void Remove(Media media)
        {
            _mediaRepository.Remove(media);
        }

        public Media Update(Media media)
        {
            return _mediaRepository.Update(media);
        }
    }
}
