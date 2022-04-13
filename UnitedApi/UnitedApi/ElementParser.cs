using UnitedApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitedApi
{
    public static class ElementParser
    {
        private static string CreateDashLikeCompound(List<string> elements)
        {
            string compound = String.Empty;
            compound = elements.Count() > 1 ?
                string.Join("-%", elements.Take(elements.Count() - 1)) + "-%" + elements.Last()
                : elements.FirstOrDefault();
            return compound;
        }

        public static string ParseElements(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new Exception("Blank name!");
            List<string> parts = name.Split(',').OrderBy(x => x).ToList();
            parts.RemoveAll(s => s == "");
            return CreateDashLikeCompound(parts);
        }

    }
}
