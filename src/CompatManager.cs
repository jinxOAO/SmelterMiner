using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmelterMiner
{
    internal class CompatManager
    {
        public const string GB_GUID = "org.LoShin.GenesisBook";

        public static bool GB = false;

        public static void Init()
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(GB_GUID))
                GB = true;
        }
    }
}
