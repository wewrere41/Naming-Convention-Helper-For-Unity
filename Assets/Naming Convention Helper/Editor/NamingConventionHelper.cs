using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

#pragma warning disable CS4014

namespace Asset_Naming_Convention_Helper
{
    public static class NamingConventionHelper
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
    }
}