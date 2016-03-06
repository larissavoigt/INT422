using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment4.Models;

namespace Assignment4.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        public Manager()
        {
        }

        public IEnumerable<InvoiceBase> InvoiceGetAll()
        {
            var c = ds.Invoices.OrderByDescending(o => o.InvoiceDate);
            return Mapper.Map<IEnumerable<InvoiceBase>>(c);
        }

        public InvoiceBase InvoiceGetById(int id)
        {
            var o = ds.Invoices.Find(id);
            return (o == null) ? null : Mapper.Map<InvoiceBase>(o);

        }

        public InvoiceWithDetail InvoiceGetByIdWithDetail(int id)
        {
            var o = ds.Invoices.Include("Customer.Employee").Include("InvoiceLines.Track.Album.Artist").Include("InvoiceLines.Track.MediaType").SingleOrDefault(p => p.InvoiceId == id);
            // var o = ds.Invoices.Include("InvoiceLines");
            return (o == null) ? null : Mapper.Map<InvoiceWithDetail>(o);
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