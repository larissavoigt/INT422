using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class PhonesController : Controller
    {
        // Collection of phones
        private List<PhoneBase> Phones;

        public PhonesController()
        {
            // Initialize the collection
            Phones = new List<PhoneBase>();

            // 1 - Add to the collection, using the original synthax
            var priv = new PhoneBase();
            priv.Id = 1;
            priv.PhoneName = "Priv";
            priv.Manufacturer = "Blackberry";
            priv.DateReleased = new DateTime(2015, 11, 6);
            priv.MSRP = 799;
            priv.ScreenSize = 5.43;
            Phones.Add(priv);

            // 2 - Add to the collection, using the newer object initializer synthax
            var galaxy = new PhoneBase
            {
                Id = 2,
                PhoneName = "Galaxy S6",
                Manufacturer = "Samsung",
                DateReleased = new DateTime(2015, 4, 10),
                MSRP = 649,
                ScreenSize = 5.1
            };
            Phones.Add(galaxy);

            // 3 - Add to the collection, using object initializer synthax, directly as the argument to the
            // Phones.Add() method
            Phones.Add(new PhoneBase
            {
                Id = 3,
                PhoneName = "iPhone 6s",
                Manufacturer = "Apple",
                DateReleased = new DateTime(2015, 9, 25),
                MSRP = 649,
                ScreenSize = 4.7
            });
        }


        // GET: Phones
        public ActionResult Index()
        {
            return View(Phones);
        }

        // GET: Phones/Details/5
        public ActionResult Details(int id)
        {
            return View(Phones[id - 1]);
        }

        // GET: Phones/Create
        public ActionResult Create()
        {
            return View(new PhoneBase());
        }

        // POST: Phones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var newItem = new PhoneBase();

                // Configure the unique identifier
                newItem.Id = Phones.Count + 1;

                // Configure string property
                newItem.PhoneName = collection["PhoneName"];
                newItem.Manufacturer = collection["Manufacturer"];

                // Configure the date (from string)
                newItem.DateReleased = Convert.ToDateTime(collection["DateReleased"]);

                // Configure numbers (from string)
                int msrp;
                double ss;
                bool isNumber;

                // MSRP
                isNumber = Int32.TryParse(collection["MSRP"], out msrp);
                newItem.MSRP = msrp;

                // Screen Size
                isNumber = double.TryParse(collection["ScreenSize"], out ss);
                newItem.ScreenSize = ss;

                // Add to the collection
                Phones.Add(newItem);

                // Show results, using existing Details View
                return View("Details", newItem);

                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /*
        // GET: Phones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Phones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Phones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Phones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
