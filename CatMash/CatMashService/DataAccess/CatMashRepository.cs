using CatMashService.Exceptions;
using CatMashService.Transverse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.DataAccess
{
    public class CatMashRepository : ICatMashRepository
    {
        private readonly CatMashDBContext _catMashDBContext;

        public CatMashRepository(CatMashDBContext catMashDBContext)
        {
            _catMashDBContext = catMashDBContext;
        }

        public bool AddMatche(TMatche matche)
        {
            var leftCatIdNotFound = _catMashDBContext.TCat.FirstOrDefault(x => x.CatId == matche.LeftCatId) == null;
            var rightCatIdNotFound = _catMashDBContext.TCat.FirstOrDefault(x => x.CatId == matche.RightCatId) == null;

            if (rightCatIdNotFound || leftCatIdNotFound)
            {
                throw new ElementNotFoundException();
            }

            var unknowMatcheResult = MatchResultHelper.IsValidMatchResult(matche.MatchResult);
            if(unknowMatcheResult)
            {
                throw new UnknownMatcheResultException();
            }

            try
            {
                _catMashDBContext.TMatche.Add(matche);

                return _catMashDBContext.SaveChanges() == 1;
            }
            catch (Exception exp)
            {
                throw new DataBaseAccessException("DataBaseAccessException", exp);
            }
        }

        public IEnumerable<TCat> GetAllCats()
        {
            return _catMashDBContext.TCat.Include(x => x.TMatcheLeftCat).Include(y => y.TMatcheRightCat);
        }

        public TCat GetCatById(int id)
        {
            var cat = _catMashDBContext.TCat.FirstOrDefault(x => x.CatId == id);

            if (cat == null)
            {
                throw new ElementNotFoundException();
            }

            return cat;
        }

        public TCat GetRandomCat()
        {
            var allCatsList = GetAllCats();
            var count = allCatsList.Count();
            var rand = new System.Random();
            var randomUser = allCatsList.Skip(rand.Next(count)).FirstOrDefault();

            return randomUser;
        }
    }
}
