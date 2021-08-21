using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCore.Objects
{
    public class ADDSWindUrl
    {
        public string Valid { get; set; }
        public string FL { get; set; }
        public string Url { get; set; }

        public static List<ADDSWindUrl> GetADDSWindUrls()
        {
            var result = new List<ADDSWindUrl>();
            result.Add(new ADDSWindUrl() { FL = "630", Valid = "06", Url = "2840" });
            result.Add(new ADDSWindUrl() { FL = "630", Valid = "12", Url = "2850" });
            result.Add(new ADDSWindUrl() { FL = "630", Valid = "18", Url = "2860" });
            result.Add(new ADDSWindUrl() { FL = "630", Valid = "24", Url = "2870" });
            result.Add(new ADDSWindUrl() { FL = "630", Valid = "30", Url = "2880" });
            result.Add(new ADDSWindUrl() { FL = "630", Valid = "36", Url = "2890" });

            result.Add(new ADDSWindUrl() { FL = "450", Valid = "06", Url = "2841" });
            result.Add(new ADDSWindUrl() { FL = "450", Valid = "12", Url = "2851" });
            result.Add(new ADDSWindUrl() { FL = "450", Valid = "18", Url = "2861" });
            result.Add(new ADDSWindUrl() { FL = "450", Valid = "24", Url = "2871" });
            result.Add(new ADDSWindUrl() { FL = "450", Valid = "30", Url = "2881" });
            result.Add(new ADDSWindUrl() { FL = "450", Valid = "36", Url = "2891" });

            result.Add(new ADDSWindUrl() { FL = "390", Valid = "06", Url = "2842" });
            result.Add(new ADDSWindUrl() { FL = "390", Valid = "12", Url = "2852" });
            result.Add(new ADDSWindUrl() { FL = "390", Valid = "18", Url = "2862" });
            result.Add(new ADDSWindUrl() { FL = "390", Valid = "24", Url = "2872" });
            result.Add(new ADDSWindUrl() { FL = "390", Valid = "30", Url = "2882" });
            result.Add(new ADDSWindUrl() { FL = "390", Valid = "36", Url = "2892" });
            //340
            result.Add(new ADDSWindUrl() { FL = "340", Valid = "06", Url = "2843" });
            result.Add(new ADDSWindUrl() { FL = "340", Valid = "12", Url = "2853" });
            result.Add(new ADDSWindUrl() { FL = "340", Valid = "18", Url = "2863" });
            result.Add(new ADDSWindUrl() { FL = "340", Valid = "24", Url = "2873" });
            result.Add(new ADDSWindUrl() { FL = "340", Valid = "30", Url = "2883" });
            result.Add(new ADDSWindUrl() { FL = "340", Valid = "36", Url = "2893" });
            //300
            result.Add(new ADDSWindUrl() { FL = "300", Valid = "06", Url = "2844" });
            result.Add(new ADDSWindUrl() { FL = "300", Valid = "12", Url = "2854" });
            result.Add(new ADDSWindUrl() { FL = "300", Valid = "18", Url = "2864" });
            result.Add(new ADDSWindUrl() { FL = "300", Valid = "24", Url = "2874" });
            result.Add(new ADDSWindUrl() { FL = "300", Valid = "30", Url = "2884" });
            result.Add(new ADDSWindUrl() { FL = "300", Valid = "36", Url = "2894" });
            //240
            result.Add(new ADDSWindUrl() { FL = "240", Valid = "06", Url = "2845" });
            result.Add(new ADDSWindUrl() { FL = "240", Valid = "12", Url = "2855" });
            result.Add(new ADDSWindUrl() { FL = "240", Valid = "18", Url = "2865" });
            result.Add(new ADDSWindUrl() { FL = "240", Valid = "24", Url = "2875" });
            result.Add(new ADDSWindUrl() { FL = "240", Valid = "30", Url = "2885" });
            result.Add(new ADDSWindUrl() { FL = "240", Valid = "36", Url = "2895" });
            //180
            result.Add(new ADDSWindUrl() { FL = "180", Valid = "06", Url = "2846" });
            result.Add(new ADDSWindUrl() { FL = "180", Valid = "12", Url = "2856" });
            result.Add(new ADDSWindUrl() { FL = "180", Valid = "18", Url = "2866" });
            result.Add(new ADDSWindUrl() { FL = "180", Valid = "24", Url = "2876" });
            result.Add(new ADDSWindUrl() { FL = "180", Valid = "30", Url = "2886" });
            result.Add(new ADDSWindUrl() { FL = "180", Valid = "36", Url = "2896" });
            //100
            result.Add(new ADDSWindUrl() { FL = "100", Valid = "06", Url = "2847" });
            result.Add(new ADDSWindUrl() { FL = "100", Valid = "12", Url = "2857" });
            result.Add(new ADDSWindUrl() { FL = "100", Valid = "18", Url = "2867" });
            result.Add(new ADDSWindUrl() { FL = "100", Valid = "24", Url = "2877" });
            result.Add(new ADDSWindUrl() { FL = "100", Valid = "30", Url = "2887" });
            result.Add(new ADDSWindUrl() { FL = "100", Valid = "36", Url = "2897" });
            //050
            result.Add(new ADDSWindUrl() { FL = "050", Valid = "06", Url = "2848" });
            result.Add(new ADDSWindUrl() { FL = "050", Valid = "12", Url = "2858" });
            result.Add(new ADDSWindUrl() { FL = "050", Valid = "18", Url = "2868" });
            result.Add(new ADDSWindUrl() { FL = "050", Valid = "24", Url = "2878" });
            result.Add(new ADDSWindUrl() { FL = "050", Valid = "30", Url = "2888" });
            result.Add(new ADDSWindUrl() { FL = "050", Valid = "36", Url = "2898" });

            return result;
        }
    }
}
