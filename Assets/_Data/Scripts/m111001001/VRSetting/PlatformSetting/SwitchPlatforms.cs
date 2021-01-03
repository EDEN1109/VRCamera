using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m111001001.Platforms
{
    public class SwitchPlatforms : MonoBehaviour
    {
        [SerializeField] private PlaygroundManager playgroundManager;

        public void OnClickUnityEditor()
        {
            playgroundManager.SwitchPlatform(Platforms.UnityEditor);
        }
        public void OnClickPC()
        {
            playgroundManager.SwitchPlatform(Platforms.PC);
        }
        public void OnClickVR()
        {
            playgroundManager.SwitchPlatform(Platforms.VR);
        }
        public void OnClickTablet()
        {
            playgroundManager.SwitchPlatform(Platforms.Tablet);
        }
    }
}
