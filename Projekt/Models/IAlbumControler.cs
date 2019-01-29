using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projekt.Models
{
   public interface IAlbumControler
    {
        ActionResult AlbumsSearched(string searched);
        ActionResult GetAlbums();
        ActionResult DeleteDatabase();
    }
}
