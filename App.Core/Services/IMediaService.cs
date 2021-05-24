using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Models;

namespace App.Core.Services
{
    public interface IMediaService
    {
        Media Add(Media media);
        Media Update(Media media);
        Media Get(int id);
        IEnumerable<Media> GetAll();
        void Remove(Media media);
    }
}
