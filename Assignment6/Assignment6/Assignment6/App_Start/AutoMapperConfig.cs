using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment6
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.CreateMap<Models.Playlist, Controllers.PlaylistBase>();
            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Models.Playlist, Controllers.PlaylistWithTracks>();
            Mapper.CreateMap<Controllers.PlaylistBase, Controllers.PlaylistEditTracksForm>();
            //      Mapper.CreateMap<Models.Playlist, Controllers.PlaylistBase>();
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();
        }
    }
}