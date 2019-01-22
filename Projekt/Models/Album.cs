using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Album
    {

        public int AlbumID { get; set; }
        public string Genere { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }

    }

    public class AlbumDB : DbContext
    {
        public System.Data.Entity.DbSet<Projekt.Models.Album> Albums { get; set; }
    }
}