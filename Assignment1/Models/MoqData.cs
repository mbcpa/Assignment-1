using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class MoqData : IMoqSongs
    {
        //Real db connection
        private DbModel db = new DbModel();

        //Data list
        public IQueryable<Song> Songs { get { return db.Songs; } }
        public IQueryable<Band> Bands { get { return db.Bands; } }

        //Delete method
        public void Delete(Song song)
        {
            db.Songs.Remove(song);
            db.SaveChanges();
        }

        //Save method
        public Song Save(Song song)
        {
            if (song.SongId == 0)
            {
                db.Songs.Add(song);
            }
            else
            {
                //Set song to modified state if id is something other than 0
                db.Entry(song).State = System.Data.Entity.EntityState.Modified;
            }

            //Save changes to database and return song object
            db.SaveChanges();
            return song;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}