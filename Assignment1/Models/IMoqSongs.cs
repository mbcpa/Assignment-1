using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public interface IMoqSongs
    {
        IQueryable<Song> Songs { get; }
        IQueryable<Band> Bands { get; }
        Song Save(Song song);
        void Delete(Song song);
        void Dispose();
    }
}
