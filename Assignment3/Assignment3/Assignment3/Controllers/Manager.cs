using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        public Manager() {  }


        public IEnumerable<EmployeeBase> EmployeeGetAll(){
            var c = ds.Employees.OrderBy(o => o.LastName);
            return Mapper.Map<IEnumerable<EmployeeBase>>(c);
        }

       public EmployeeBase EmployeeEditContactInfo(EmployeeEditContactInfo newItem) {
            //Attempt to fetch the object
            var o = ds.Employees.Find(newItem.EmployeeId);
            if (o == null) {
                return null;
            }

            else {
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                return Mapper.Map<EmployeeBase>(o);
           }


        }

        public EmployeeBase EmployeeGetById(int id) {
            var c = ds.Employees.Find(id);
            return (c == null) ? null : Mapper.Map<EmployeeBase>(c);
        }


        public IEnumerable<TrackBase> TrackGetAll()
        {
            var t = ds.Tracks.OrderBy(o=>o.AlbumId).ThenBy(o=>o.Name);
            return Mapper.Map<IEnumerable<TrackBase>>(t);
        }

      
        public IEnumerable<TrackBase> TrackGetAllPop()
        {
            var t = ds.Tracks.Where(o=>o.GenreId==9).OrderBy(o => o.Name);
            return Mapper.Map<IEnumerable<TrackBase>>(t);
        }

        
        public IEnumerable<TrackBase> TrackGetAllDeepPurple()
        {
            var t = ds.Tracks.Where(o => o.Composer.Contains("Jon Lord")).OrderBy(o => o.TrackId);
            return Mapper.Map<IEnumerable<TrackBase>>(t);
        }

   
      
        public IEnumerable<TrackBase> TrackGetAllTop100Longest()
        {
            var t = ds.Tracks.OrderByDescending(o=>o.Milliseconds).Take(100);
            return Mapper.Map<IEnumerable<TrackBase>>(t);
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