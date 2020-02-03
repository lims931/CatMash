using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.DataAccess
{
    public interface ICatMashRepository
    {
        bool AddMatche(TMatche matche);

        TCat GetCatById(int id);

        IEnumerable<TCat> GetAllCats();

        TCat GetRandomCat();
    }
}
