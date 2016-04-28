using System.Collections.Generic;
using Zad7.Models;

namespace Zad7.Interfaces
{
    public interface IArtistsRepository
    {
        void AddArtits(Artist artist);
        Artist GetArtist(int id);
        List<Artist> GetAllArtists();
        void UpdateArtist(Artist artist);
        bool DeleteArtist(int id);
    }
}
