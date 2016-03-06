using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment4
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();
            Mapper.CreateMap<Models.Invoice, Controllers.InvoiceBase>();
            Mapper.CreateMap<Models.Invoice, Controllers.InvoiceWithDetail>();
            Mapper.CreateMap<Models.InvoiceLine, Controllers.InvoiceLineBase>();
            Mapper.CreateMap<Models.InvoiceLine, Controllers.InvoiceLineWithDetail>();
            //  Mapper.CreateMap<Models.InvoiceLine, Controllers.InvoiceWithDetail>();
        }
    }
}