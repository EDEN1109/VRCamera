using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace m111001001.Platforms
{
    public enum Platforms
    {
        None,
        UnityEditor,
        PC,
        VR,
        Tablet
    }
    public class PlaygroundManager : MonoBehaviour
    {
        [HideInInspector] public Platforms currentPlatform;
        [Header("PlaySetting")]
        public Platforms platforms;
        [SerializeField] private GameObject UnitySettingPrefab;
        [SerializeField] private GameObject PCSettingPrefab;
        [SerializeField] private GameObject VRSettingPrefab;
        [SerializeField] private GameObject TabletSettingPrefab;

        private Transform player;
        private GameObject m_Camera;

        void Awake()
        {
            this.tag = "Player";
            this.name = "Player";
            player = GameObject.FindGameObjectWithTag("Player").transform;

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            SetPlaySetting();
        }

        private void SetPlaySetting()
        {
            switch (platforms)
            {
                case Platforms.None:
                    NoneSet();
                    break;
                case Platforms.UnityEditor:
                    UnityEditorSet();
                    break;
                case Platforms.PC:
                    PCSet();
                    break;
                case Platforms.VR:
                    VRSet();
                    break;
                case Platforms.Tablet:
                    TabletSet();
                    break;
            }
        }

        private void NoneSet()
        {
            currentPlatform = Platforms.None;
        }

        private void UnityEditorSet()
        {
            currentPlatform = Platforms.UnityEditor;
            m_Camera = Instantiate(UnitySettingPrefab, player);
            m_Camera.transform.parent = player;
            player.gameObject.AddComponent<UnityEditorSetting>();
        }

        private void PCSet()
        {
            currentPlatform = Platforms.PC;
            m_Camera = Instantiate(PCSettingPrefab, player);
            m_Camera.transform.parent = player;
            player.gameObject.AddComponent<PCSetting>();
        }

        private void VRSet()
        {
            currentPlatform = Platforms.VR;
            m_Camera = Instantiate(VRSettingPrefab, player);
            m_Camera.transform.parent = player;
            player.gameObject.AddComponent<VRSetting>();
        }

        private void TabletSet()
        {
            currentPlatform = Platforms.Tablet;
            m_Camera = Instantiate(TabletSettingPrefab, player);
            m_Camera.transform.parent = player;
            player.gameObject.AddComponent<TabletSetting>();
        }

        public void SwitchPlatform(Platforms switchPlatform)
        {
            if (currentPlatform != switchPlatform)
            {
                Destroy(m_Camera);

                switch (platforms)
                {
                    case Platforms.None:
                        break;
                    case Platforms.UnityEditor:
                        Destroy(player.gameObject.GetComponent<UnityEditorSetting>());
                        break;
                    case Platforms.PC:
                        Destroy(player.gameObject.GetComponent<PCSetting>());
                        break;
                    case Platforms.VR:
                        Destroy(player.gameObject.GetComponent<VRSetting>());
                        break;
                    case Platforms.Tablet:
                        Destroy(player.gameObject.GetComponent<TabletSetting>());
                        break;
                }

                platforms = switchPlatform;
                SetPlaySetting();
            }
        }
    }
}