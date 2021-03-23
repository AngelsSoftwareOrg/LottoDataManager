using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator
{
    public enum GeneratorType
    {
        PERSONAL_PICK = 0,
        HISTORICAL_FREQ_RANDOM = 1,
        LUCKY_PICK = 2,
        NUMBERS_NOT_YET_BETTED_THIS_CURRENT_SEASON = 3,
        RANDOM_NUMBERS_USING_JACKPOTS_WINNING_DIGITS = 4,
        RANDOM_PATTERN_SEQUENCE = 5,
        RANDOM_PICK_A_SEQ_104_176_1 = 6,
        RANDOM_PICK_A_SEQ_104_176_2 = 7,
        RANDOM_PICK_A_SEQ_104_176_3 = 8,
        TOP_DRAW_NUMBERS_THIS_CURRENT_SEASON = 9,
        TOP_DRAWN_NUMBERS_FROM_JACKPOTS = 10,
        TOP_DRAW_NUMBERS_USING_DATE_RANGE = 11,
        TOP_DRAW_USING_PREVIOUS_SEASON_NUM_RES = 12,
        NUMBER_NOT_YET_PICK_UP_GENERATOR = 13,
        RANDOM_PREDICTION = 14
    }
}
