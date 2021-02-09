using System;
using Triangles.Models;

namespace Triangles.Helpers
{
    public static class Functions
    {
        private static Triangle t;

        public static void Calculate(Triangle triangle)
        {
            t = triangle;

            if (!IsValid())
            {
                t.Classification = Classification.Invalid;
                t.Degree1 = 0;
                t.Degree2 = 0;
                t.Degree3 = 0;
            }
            else
            {
                SetClassification();
                SetDegrees();
            }

            SetClassificationToString();
            SetDegreesToString();
        }

        private static bool IsValid()
        {
            if (t.SideA == 0 || t.SideB == 0 || t.SideC == 0)
                return false;

            // Make sure no two sides are less than or equal to the other side
            if ((t.SideA + t.SideB) <= t.SideC)
                return false;
            if ((t.SideA + t.SideC) <= t.SideB)
                return false;
            if ((t.SideB + t.SideC) <= t.SideA)
                return false;

            return true;
        }

        private static void SetClassification()
        {
            // first, check for all sides equal
            if (t.SideA == t.SideB && t.SideB == t.SideC && t.SideA == t.SideC)
            {
                t.Classification = Classification.Equilateral | Classification.Acute;
            }
            // check for two sides equal
            else if (t.SideA == t.SideB || t.SideB == t.SideC || t.SideA == t.SideC)
            {
                // two sides are equal. now see what other classification it has
                t.Classification = Classification.Isosceles;
                UsePythagoreanTheorem();
            }
            // scalene. now see what other classification it has
            else
            {
                t.Classification = Classification.Scalene;
                UsePythagoreanTheorem();
            }
        }

        private static void UsePythagoreanTheorem()
        {
            int smallSide1;
            int smallSide2;
            int largestSide;

            if (t.SideA > t.SideB && t.SideA > t.SideC)
            {
                smallSide1 = t.SideB;
                smallSide2 = t.SideC;
                largestSide = t.SideA;
            }
            else if (t.SideB > t.SideA && t.SideB > t.SideC)
            {
                smallSide1 = t.SideA;
                smallSide2 = t.SideC;
                largestSide = t.SideB;
            }
            else
            {
                smallSide1 = t.SideA;
                smallSide2 = t.SideB;
                largestSide = t.SideC;
            }

            if (Math.Pow(smallSide1, 2) + Math.Pow(smallSide2, 2) == Math.Pow(largestSide, 2))
                t.Classification |= Classification.Right;
            else if (Math.Pow(smallSide1, 2) + Math.Pow(smallSide2, 2) > Math.Pow(largestSide, 2))
                t.Classification |= Classification.Acute;
            else
                t.Classification |= Classification.Obtuse;
        }

        private static void SetDegrees()
        {
            var cosA = (Math.Pow(t.SideB, 2) + Math.Pow(t.SideC, 2) - Math.Pow(t.SideA, 2)) / (2 * t.SideB * t.SideC);
            var cosB = (Math.Pow(t.SideA, 2) + Math.Pow(t.SideC, 2) - Math.Pow(t.SideB, 2)) / (2 * t.SideA * t.SideC);
            var cosC = (Math.Pow(t.SideA, 2) + Math.Pow(t.SideB, 2) - Math.Pow(t.SideC, 2)) / (2 * t.SideA * t.SideB);

            t.Degree1 = Math.Acos(cosA);
            t.Degree2 = Math.Acos(cosB);
            t.Degree3 = Math.Acos(cosC);

            t.Degree1 = (t.Degree1 * 180) / Math.PI;
            t.Degree2 = (t.Degree2 * 180) / Math.PI;
            t.Degree3 = (t.Degree3 * 180) / Math.PI;

            t.Degree1 = Math.Round(t.Degree1, 2, MidpointRounding.AwayFromZero);
            t.Degree2 = Math.Round(t.Degree2, 2, MidpointRounding.AwayFromZero);
            t.Degree3 = Math.Round(t.Degree3, 2, MidpointRounding.AwayFromZero);
        }

        private static void SetClassificationToString()
        {
            if (AnySideBlank())
                t.ClassificationToString = string.Empty;
            else
            {
                t.ClassificationToString = t.Classification == Classification.Invalid
                    ? "Invalid triangle"
                    : string.Format("Valid {0} triangle", t.Classification.ToString());
            }
        }

        private static void SetDegreesToString()
        {
            t.DegreesToString = AnySideBlank() ? string.Empty : string.Format("{0}   {1}   {2}", t.Degree1, t.Degree2, t.Degree3);
        }

        private static bool AnySideBlank()
        {
            if (t.SideAText == string.Empty)
                return true;
            if (t.SideBText == string.Empty)
                return true;
            if (t.SideCText == string.Empty)
                return true;

            return false;
        }
    }
}
