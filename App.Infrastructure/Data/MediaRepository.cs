using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Core.Models;
using App.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data
{
    public class MediaRepository : IMediaRepository
    {
        private readonly AppDbContext _appDbContext;

        public MediaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Media Add(Media media)
        {
            _appDbContext.Medias.Add(media);
            _appDbContext.SaveChanges();

            return media;
        }

        public Media Get(int id)
        {
            return _appDbContext.Medias
                .Include(m => m.User)
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Media> GetAll()
        {
            return _appDbContext.Medias
                .Include(m => m.User)
                .ToList();
        }

        public void Remove(Media media)
        {
            _appDbContext.Medias.Remove(media);
            _appDbContext.SaveChanges();
        }

        public Media Update(Media media)
        {
            var current = Get(media.Id);

            if (current == null)
                return null;

            _appDbContext.Entry(current)
                .CurrentValues
                .SetValues(media);

            _appDbContext.Medias.Update(current);

            _appDbContext.SaveChanges();

            return current;
        }
    }
}
