using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment6.Models;

namespace Assignment6.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;
            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
            // If necessary, add constructor code here
        }


        public IEnumerable<PlaylistBase> PlaylistGetAll()
        {
            return Mapper.Map<IEnumerable<PlaylistBase>>(ds.Playlists.Include("Tracks").OrderBy(s => s.Name));
        }

        public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<TrackBase>>(ds.Tracks.OrderBy(s => s.Name));
        }
        public IEnumerable<PlaylistWithTracks> PlaylistGetAllWithTracks()
        {
            return Mapper.Map<IEnumerable<PlaylistWithTracks>>
                (ds.Playlists.Include("Tracks").OrderBy(e => e.Name));
        }

        public PlaylistWithTracks PlaylistGetByIdWithDetail(int id) {
            var o = ds.Playlists.Include("Tracks").SingleOrDefault(e => e.PlaylistId == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<PlaylistWithTracks>(o);

        }


        public PlaylistWithTracks PlaylistEditTracks(PlaylistEditTracks newItem)
        {
            // Attempt to fetch the object

            // When editing an object with a to-many collection,
            // and you wish to edit the collection,
            // MUST fetch its associated collection

            var o = ds.Playlists.Include("Tracks").SingleOrDefault(e => e.PlaylistId == newItem.Id);

            if (o == null)
            {
                // Problem - object was not found, so return
                return null;
            }
            else
            {
                // Update the object with the incoming values

                // First, clear out the existing collection
                o.Tracks.Clear();

                // Then, go through the incoming items
                // For each one, add to the fetched object's collection
                foreach (var item in newItem.TrackIds)
                {
                    var a = ds.Tracks.Find(item);
                    o.Tracks.Add(a);
                }
                // Save changes
                ds.SaveChanges();

                return Mapper.Map<PlaylistWithTracks>(o);
            }
        }














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