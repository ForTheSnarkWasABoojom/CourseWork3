using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterApi
{
    public class ElementParser
    {
        public static string ParseElements(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new Exception("Blank name!");
            List<string> parts = name.Split(',').OrderBy(x => x).ToList();
            parts.RemoveAll(s => s == "");
            return CreateDashLikeCompound(parts);
        }

        private static string CreateDashLikeCompound(List<string> elements)
        {
            string compound = String.Empty;
            compound = elements.Count() > 1 ?
                string.Join("%2C", elements.Take(elements.Count() - 1)) + "%2C" + elements.Last()
                : elements.FirstOrDefault();
            return compound;
        }
    }
}
