using System;
using System.Collections.Generic;

namespace CatMashService.DataAccess
{
    public partial class TMatche
    {
        public int MatcheId { get; set; }
        public int LeftCatId { get; set; }
        public int RightCatId { get; set; }
        public string MatchResult { get; set; }

        public virtual TCat LeftCat { get; set; }
        public virtual TCat RightCat { get; set; }
    }
}
