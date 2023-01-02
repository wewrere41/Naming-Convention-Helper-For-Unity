namespace Asset_Naming_Convention_Helper
{
    using System;
    using UnityEngine;

    [CreateAssetMenu(fileName = "NamingConventions", menuName = "Naming Convention Helper")]
    public class NamingConventionDataSO : ScriptableObject
    {
        public string TargetFolder = "";
        public NamingConventionData[] NamingConventionDatas;

        private void OnValidate()
        {
            NamingConventionHelper.NamingConventions = NamingConventionDatas;
            NamingConventionHelper.TargetPath = TargetFolder;
        }
    }

    [Serializable]
    public class NamingConventionData
    {
        [field: SerializeField] public string[] Extensions { get; private set; }
        [field: SerializeField] public string[] Prefixes { get; private set; }

        public NamingConventionData(string[] extensions, string[] prefixes) =>
            (Extensions, Prefixes) = (extensions, prefixes);
    }
}