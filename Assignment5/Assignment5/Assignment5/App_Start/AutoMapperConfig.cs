using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment5
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            Mapper.CreateMap <Models.Album,Controllers.AlbumBase>();
            Mapper.CreateMap<Models.MediaType, Controllers.MediaTypeBase>();
            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Models.Track, Controllers.TrackWithDetail>();
            Mapper.CreateMap<Controllers.TrackAdd, Models.Track>();
            Mapper.CreateMap<Controllers.TrackAdd, Controllers.TrackAddForm>();
            Mapper.CreateMap<Controllers.TrackAddForm, Models.Track>();

        }
    }
}