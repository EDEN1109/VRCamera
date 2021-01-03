﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using m111001001.Handler;

// TO DO : namespace 이름 변경
namespace m111001001.Utils
{
    // This class simply allows the user to return to the main menu.
    public class ReturnToMainMenu : MonoBehaviour
    {
        [SerializeField] private string m_MenuSceneName = "MainMenu";   // The name of the main menu scene.
        [SerializeField] private VRInput m_VRInput;                     // Reference to the VRInput in order to know when Cancel is pressed.
        [SerializeField] private VRCameraFade m_VRCameraFade;           // Reference to the script that fades the scene to black.


        private void OnEnable ()
        {
            m_VRInput.OnCancel.AddListener(HandleCancel);
        }


        private void OnDisable ()
        {
            m_VRInput.OnCancel.RemoveListener(HandleCancel);
        }


        private void HandleCancel ()
        {
            StartCoroutine (FadeToMenu ());
        }


        private IEnumerator FadeToMenu ()
        {
            // Wait for the screen to fade out.
            yield return StartCoroutine (m_VRCameraFade.BeginFadeOut (true));

            // Load the main menu by itself.
            SceneManager.LoadScene(m_MenuSceneName, LoadSceneMode.Single);
        }
    }
}