using System.Collections.Generic;
using System.Linq;

namespace AuroraSeeker.Blocky.Shared.HumanCommands
{
    public static class HumanCommandUtils
    {
        public static string ConcatenateAliases(IEnumerable<string> aliases)
        {
            var aliasesAsList = aliases.ToList();
            
            if (!aliasesAsList.Any()) return "";

            var result = aliasesAsList[0];

            for (var i = 1; i < aliasesAsList.Capacity; i++)
            {
                result += $" / { aliasesAsList[i]}";
            }

            return result;
        }
    }
}