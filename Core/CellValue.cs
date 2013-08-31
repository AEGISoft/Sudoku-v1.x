using System;
using System.Collections.Generic;

namespace AEGIS.Sudoku.Solver
{
    public abstract class CellValue
    {
        #region Unique CellValue instances
        //create all possible values at once
        private static readonly CellValue[] UniqueCellValues = new[]
        {
            Unknown.Create(), 

            One.Create(), 
            Two.Create(), 
            Three.Create(), 
            Four.Create(), 
            Five.Create(), 
            Six.Create(), 
            Seven.Create(), 
            Eight.Create(), 
            Nine.Create(), 

            Error.Create()
        };

        //location is zero based
        private const int UnknownIndex = 0;

        private const int OneIndex = 1;
        private const int TwoIndex = 2;
        private const int ThreeIndex = 3;
        private const int FourIndex = 4;
        private const int FiveIndex = 5;
        private const int SixIndex = 6;
        private const int SevenIndex = 7;
        private const int EightIndex = 8;
        private const int NineIndex = 9;

        private const int ErrorIndex = 10;
        #endregion

        #region Valid CellValues
        //always return the one and only instance of a cell value
        public static Unknown Unknown   { get { return (Unknown)    UniqueCellValues[UnknownIndex]; } }

        public static One One           { get { return (One)        UniqueCellValues[OneIndex];     } }
        public static Two Two           { get { return (Two)        UniqueCellValues[TwoIndex];     } }
        public static Three Three       { get { return (Three)      UniqueCellValues[ThreeIndex];   } }
        public static Four Four         { get { return (Four)       UniqueCellValues[FourIndex];    } }
        public static Five Five         { get { return (Five)       UniqueCellValues[FiveIndex];    } }
        public static Six Six           { get { return (Six)        UniqueCellValues[SixIndex];     } }
        public static Seven Seven       { get { return (Seven)      UniqueCellValues[SevenIndex];   } }
        public static Eight Eight       { get { return (Eight)      UniqueCellValues[EightIndex];   } }
        public static Nine Nine         { get { return (Nine)       UniqueCellValues[NineIndex];    } }

        public static Error Error       { get { return (Error)      UniqueCellValues[ErrorIndex];   } }
        #endregion

        #region Real CellValues
        public static List<CellValue> RealValues { get { return new List<CellValue> { One, Two, Three, Four, Five, Six, Seven, Eight, Nine }; } }

        public static bool RealValue(CellValue value) { return (RealValues.Contains(value)); }
        #endregion

        #region Conversions
        public static CellValue From(int value)
        {
            // Input Validation
            if (value < 1 || 9 < value) throw new ArgumentOutOfRangeException("value",value,"must be between 1 and 9"); 

            //reuse single instance of each possible cell value
            var zeroBasedIndex = value;
            return UniqueCellValues[zeroBasedIndex];
        }
        #endregion
    }

    #region Possible CellValues
    // should only be created (once) by the base class (CellValue) !
    public class One        : CellValue { internal static CellValue Create() { return new One();    } private One()     { } }
    public class Two        : CellValue { internal static CellValue Create() { return new Two();    } private Two()     { } }
    public class Three      : CellValue { internal static CellValue Create() { return new Three();  } private Three()   { } }
    public class Four       : CellValue { internal static CellValue Create() { return new Four();   } private Four()    { } }
    public class Five       : CellValue { internal static CellValue Create() { return new Five();   } private Five()    { } }
    public class Six        : CellValue { internal static CellValue Create() { return new Six();    } private Six()     { } }
    public class Seven      : CellValue { internal static CellValue Create() { return new Seven();  } private Seven()   { } }
    public class Eight      : CellValue { internal static CellValue Create() { return new Eight();  } private Eight()   { } }
    public class Nine       : CellValue { internal static CellValue Create() { return new Nine();   } private Nine()    { } }

    public class Unknown    : CellValue { internal static CellValue Create() { return new Unknown();} private Unknown() { } }
    public class Error      : CellValue { internal static CellValue Create() { return new Error();  } private Error()   { } }
    #endregion

}