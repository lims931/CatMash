using System;
using System.Collections.Generic;

namespace CatMashService.DataAccess
{
    public partial class TCat
    {
        public TCat()
        {
            TMatcheLeftCat = new HashSet<TMatche>();
            TMatcheRightCat = new HashSet<TMatche>();
        }

        public int CatId { get; set; }
        public string CatUrl { get; set; }

        public virtual ICollection<TMatche> TMatcheLeftCat { get; set; }
        public virtual ICollection<TMatche> TMatcheRightCat { get; set; }
    }
}
