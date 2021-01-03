using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m111001001.Platforms
{
    public class SwitchPlatforms : MonoBehaviour
    {
        [SerializeField] private PlaygroundManager playgroundManager;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

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
