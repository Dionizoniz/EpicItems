using UnityEditor;
using UnityEngine;

namespace EpicItems.Core.Providers
{
    public class ExitGameProvider : IExitGameProvider
    {
        public void ExitGame()
        {
            if (Application.isEditor)
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
