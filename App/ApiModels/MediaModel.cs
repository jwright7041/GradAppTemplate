﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.ApiModels
{
    public class MediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
    }
}
