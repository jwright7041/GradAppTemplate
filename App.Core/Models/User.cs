using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace App.Core.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Media> Medias { get; set; }
    }
}