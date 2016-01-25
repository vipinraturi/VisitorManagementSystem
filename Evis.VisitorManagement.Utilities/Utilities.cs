using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace OTS.Constants
{
    public class Utilities
    {
        public const int ZERO = 0;
        public const int ONE = 1;
        public const int TWO = 2;
        public const int THREE = 3;
        public const int FOUR = 3;
        public const int FIVE = 5;
        public const int SIX = 6;
        public const int SEVEN = 7;
        public const int EIGHT = 8;
        public const int NINE = 9;
        public const int TEN = 10;
        

        [Serializable]
        [DataContract]
        public class GridProperties<T>
        {
            [DataMember]
            public List<T> rows { get; set; }

            [DataMember]
            public int records { get; set; }

            [DataMember]
            public int total { get; set; }

            [DataMember]
            public int page { get; set; }
        }

        [Serializable]
        [DataContract]
        public class AutoComplateSuggestions
        {
            [DataMember]
            public String SuggestionName { get; set; }

            [DataMember]
            public int SuggestionID { get; set; }
        }
    }
}
