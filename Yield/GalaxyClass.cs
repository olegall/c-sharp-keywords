﻿using System;
using System.Diagnostics;

namespace Yield
{
    public static class GalaxyClass
    {
        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        public static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Debug.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }

        public class Galaxies
        {
            public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
            {
                get // в get всегда 1 return, а тут много
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }
        }
    }
}
