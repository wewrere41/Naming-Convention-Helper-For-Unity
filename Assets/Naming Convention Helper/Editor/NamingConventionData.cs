using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

#pragma warning disable CS4014

namespace Asset_Naming_Convention_Helper
{
    public static class NamingConventionDataHelper
    {
        public static string TargetPath;
        public static NamingConventionData[] NamingConventions;

        #region FIRST LOAD

        [InitializeOnLoadMethod]
        private static void Initialize() => InitializeAfterDelay();

        private static async Task InitializeAfterDelay()
        {
            await Task.Delay(100);

            if (TargetPath == null)
            {
                var namingConventionDataSO = Resources.Load<NamingConventionDataSO>("NamingConventions");
                TargetPath = namingConventionDataSO.TargetFolder;
                NamingConventions = namingConventionDataSO.NamingConventionDatas;
            }
        }

        #endregion

        public static bool IsExtensionMatch(this NamingConventionData namingConventionData, string extension) =>
            namingConventionData.Extensions.Any(x => x == extension);

        public static bool TryRename(this NamingConventionData namingConventionData, string assetName,
            out string result)
        {
            result = namingConventionData.Prefixes[0] + assetName;
            return !namingConventionData.Prefixes.Any(assetName.StartsWith);
        }
    }
}