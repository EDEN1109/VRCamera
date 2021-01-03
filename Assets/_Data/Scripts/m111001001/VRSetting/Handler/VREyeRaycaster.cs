using System;
using UnityEngine;
using m111001001.Interaction;

// TO DO : namespace 이름 변경
namespace m111001001.Handler
{
    // In order to interact with objects in the scene
    // this class casts a ray into the scene and if it finds
    // a VRInteractiveItem it exposes it for other classes to use.
    // This script should be generally be placed on the camera.
    [RequireComponent(typeof(VRInput))]
    [RequireComponent(typeof(Reticle))]
    public class VREyeRaycaster : MonoBehaviour
    {
        public event Action<RaycastHit> OnRaycasthit;                   // This event is called every frame that the user's gaze is over a collider.

        [SerializeField] private Transform m_Camera;                    // Usually MainCamera, In VR mode Right Camera.
        [SerializeField] private LayerMask exclusionLayers;           // Layers to exclude from the raycast.
        [SerializeField] private Reticle reticle;                     // The reticle, if applicable.
        [SerializeField] private VRInput vrInput;                     // Used to call input based events on the current VRInteractiveItem.
        [SerializeField] private bool isShow;                   // Optionally show the debug ray.
        [SerializeField] private float debugRayLength = 5f;           // Debug ray length.
        [SerializeField] private float debugRayDuration = 1f;         // How long the Debug ray will remain visible.
        [SerializeField] private float rayLength = 500f;              // How far into the scene the ray is cast.
     
        private VRInteractive currentInteractible;                //The current interactive item
        private VRInteractive lastInteractible;                   //The last interactive item


        // Utility for other classes to get the current interactive item
        public VRInteractive CurrentInteractible
        {
            get { return currentInteractible; }
        }

        
        private void OnEnable()
        {
            vrInput.OnMouseClick.AddListener(HandleClick);
            vrInput.OnMouseDoubleClick.AddListener(HandleDoubleClick);
            vrInput.OnMouseUp.AddListener(HandleUp);
            vrInput.OnMouseDown.AddListener(HandleDown);
        }


        private void OnDisable ()
        {
            vrInput.OnMouseClick.RemoveListener(HandleClick);
            vrInput.OnMouseDoubleClick.RemoveListener(HandleDoubleClick);
            vrInput.OnMouseUp.RemoveListener(HandleUp);
            vrInput.OnMouseDown.RemoveListener(HandleDown);
        }

        private void Update()
        {
            EyeRaycast();
        }

      
        private void EyeRaycast()
        {
            // Show the debug ray if required
            if (isShow)
            {
                Debug.DrawRay(m_Camera.position, m_Camera.forward * debugRayLength, Color.blue, debugRayDuration);
            }

            // Create a ray that points forwards from the camera.
            Ray ray = new Ray(m_Camera.position, m_Camera.forward);
            if (reticle.isVR)
            {
                ray = m_Camera.GetComponent<Camera>().ScreenPointToRay(reticle.m_Dots[1].position);
            }
            RaycastHit hit;
            
            // Do the raycast forweards to see if we hit an interactive item
            if (Physics.Raycast(ray, out hit, rayLength, ~exclusionLayers))
            {
                VRInteractive interactible = hit.collider.GetComponent<VRInteractive>(); //attempt to get the VRInteractiveItem on the hit object
                currentInteractible = interactible;

                // If we hit an interactive item and it's not the same as the last interactive item, then call Over
                if (interactible && currentInteractible != lastInteractible)
                {
                    if(reticle)
                    {
                        reticle.fillInTime(interactible);
                        reticle.Show();
                    }
                    
                    interactible.ReticleEnter();
                }
                else if(interactible == null)
                {
                    if (reticle)
                    {
                        reticle.stopFilling();
                        reticle.Hide();
                    }
                }

                // Deactive the last interactive item 
                if (interactible != lastInteractible)
                {
                    DeactiveLastInteractible();
                }

                lastInteractible = interactible;

                if (OnRaycasthit != null)
                    OnRaycasthit(hit);
                
            }
            else
            {
                // Nothing was hit, deactive the last interactive item.
                DeactiveLastInteractible();
                currentInteractible = null;

                // Position the reticle at default distance.
                if (reticle)
                {
                    reticle.stopFilling();
                    reticle.Hide();
                }
            }
        }


        private void DeactiveLastInteractible()
        {
            if (lastInteractible == null)
                return;

            lastInteractible.ReticleExit();
            lastInteractible = null;
        }


        private void HandleUp()
        {
            if (currentInteractible != null)
                currentInteractible.MouseUp();
        }


        private void HandleDown()
        {
            if (currentInteractible != null)
                currentInteractible.MouseDown();
        }


        private void HandleClick()
        {
            if (currentInteractible != null)
                currentInteractible.MouseClick();
        }


        private void HandleDoubleClick()
        {
            if (currentInteractible != null)
                currentInteractible.MouseDoubleClick();

        }
    }
}