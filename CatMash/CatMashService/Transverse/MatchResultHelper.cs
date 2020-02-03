using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Transverse
{
    public static class MatchResultHelper
    {
        private static readonly string LEFT_CAT_WIN = "1";
        private static readonly string RIGHT_CAT_WIN = "2";
        private static readonly string DRAW = "X";

        public static bool IsValidMatchResult(string matchResult)
        {
            return matchResult != LEFT_CAT_WIN && matchResult != RIGHT_CAT_WIN && matchResult != DRAW;
        }
    }
}
