using UnityEngine;

namespace EpicItems.Core.Engine
{
    public class ExtendedScriptableObject : ScriptableObject
    {
        private void Awake()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
    }
}
