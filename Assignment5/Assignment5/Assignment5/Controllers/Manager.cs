using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment5.Models;

namespace Assignment5.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {
            // If necessary, add constructor code here
        }


        public IEnumerable<AlbumBase> AlbumGetAll() {
            return Mapper.Map<IEnumerable<AlbumBase>>(ds.Albums);
        }


        public AlbumBase AlbumGetById(int id) {
            var o = ds.Albums.Find(id);
            return (o == null) ? null : Mapper.Map<AlbumBase>(o);
        }


        public IEnumerable<MediaTypeBase> MediaTypeGetAll() {
            return Mapper.Map<IEnumerable<MediaTypeBase>>(ds.MediaTypes);
        }

        public MediaTypeBase MediaTypeGetById(int id) {
            var o = ds.MediaTypes.Find(id);
            return (o == null) ? null : Mapper.Map<MediaTypeBase>(o);


        }


        public TrackBase TrackGetById(int id) {
            
            var o = ds.Tracks.Find(id);
            return (o == null) ? null : Mapper.Map<TrackBase>(o);

        }

        public IEnumerable<TrackBase> TrackGetAll()
        {

            

            return Mapper.Map<IEnumerable<TrackBase>>(ds.Tracks);

        }


         public IEnumerable<TrackWithDetail> TrackGetAllWithDetail() {
      
            
            var o = ds.Tracks.Include("MediaType").Include("Album");
            
            return Mapper.Map<IEnumerable<TrackWithDetail>>(o);
                }

         public TrackWithDetail TrackGetByIdWithDetail(int id)
                {
                     var o = ds.Tracks.Include("MediaType").Include("Album").SingleOrDefault(p=>p.TrackId==id);
                    return (o == null) ? null : Mapper.Map<TrackWithDetail>(o);

                }


        public TrackWithDetail TrackAdd(TrackAddForm newItem) {
            System.Diagnostics.Debug.WriteLine("Adding a track");

            var a = ds.Albums.Find(newItem.AlbumId);
            var t = ds.MediaTypes.Find(newItem.MediaTypeId);

            System.Diagnostics.Debug.WriteLine("Media Type is " + t);



            if (a == null)
            {
                return null;
            }

            else {
                var addedItem = ds.Tracks.Add(Mapper.Map<Track>(newItem));
                addedItem.Album = a;
                ds.SaveChanges();
                return (addedItem == null) ? null : Mapper.Map<TrackWithDetail>(addedItem);

            }
             


        }


        /*
        public IEnumerable<TrackBase> TrackGetAll() {
            var c = ds.Tracks.OrderByDescending(o => o.Name);

            return Mapper.Map<IEnumerable<TrackBase>>(c);

        }*/


       

       





        /*
        public IEnumerable<TrackWithDetail> TrackGetAll() {
          

           return Mapper.Map<IEnumerable<TrackWithDetail>>(o);
        }
        */

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()
    }
}