using System.Collections.Generic;
using Zad7.Models;

namespace Zad7.Interfaces
{
    public interface IPaintingsRepository
    {
        bool AddPainting(Painting painting);
        Painting GetPainting(int id);
        List<Painting> GetAllPaintings();
        bool UpdatePainting(Painting painting);
        bool DeletePainting(int id);
    }
}
