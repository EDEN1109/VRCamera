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
        [SerializeField] private LayerMask m_ExclusionLayers;           // Layers to exclude from the raycast.
        [SerializeField] private Reticle m_Reticle;                     // The reticle, if applicable.
        [SerializeField] private VRInput m_VrInput;                     // Used to call input based events on the current VRInteractiveItem.
        [SerializeField] private bool m_ShowDebugRay;                   // Optionally show the debug ray.
        [SerializeField] private float m_DebugRayLength = 5f;           // Debug ray length.
        [SerializeField] private float m_DebugRayDuration = 1f;         // How long the Debug ray will remain visible.
        [SerializeField] private float m_RayLength = 500f;              // How far into the scene the ray is cast.
     
        private VRInteractive m_CurrentInteractible;                //The current interactive item
        private VRInteractive m_LastInteractible;                   //The last interactive item


        // Utility for other classes to get the current interactive item
        public VRInteractive CurrentInteractible
        {
            get { return m_CurrentInteractible; }
        }

        
        private void OnEnable()
        {
            m_VrInput.OnMouseClick.AddListener(HandleClick);
            m_VrInput.OnMouseDoubleClick.AddListener(HandleDoubleClick);
            m_VrInput.OnMouseUp.AddListener(HandleUp);
            m_VrInput.OnMouseDown.AddListener(HandleDown);
        }


        private void OnDisable ()
        {
            m_VrInput.OnMouseClick.RemoveListener(HandleClick);
            m_VrInput.OnMouseDoubleClick.RemoveListener(HandleDoubleClick);
            m_VrInput.OnMouseUp.RemoveListener(HandleUp);
            m_VrInput.OnMouseDown.RemoveListener(HandleDown);
        }

        void Awake()
        {

        }

        private void Update()
        {
            EyeRaycast();
        }

      
        private void EyeRaycast()
        {
            // Show the debug ray if required
            if (m_ShowDebugRay)
            {
                Debug.DrawRay(m_Camera.position, m_Camera.forward * m_DebugRayLength, Color.blue, m_DebugRayDuration);
            }

            // Create a ray that points forwards from the camera.
            Ray ray = new Ray(m_Camera.position, m_Camera.forward);
            if (m_Reticle.isVR)
            {
                ray = m_Camera.GetComponent<Camera>().ScreenPointToRay(m_Reticle.m_Dots[1].position);
            }
            RaycastHit hit;
            
            // Do the raycast forweards to see if we hit an interactive item
            if (Physics.Raycast(ray, out hit, m_RayLength, ~m_ExclusionLayers))
            {
                VRInteractive interactible = hit.collider.GetComponent<VRInteractive>(); //attempt to get the VRInteractiveItem on the hit object
                m_CurrentInteractible = interactible;

                // If we hit an interactive item and it's not the same as the last interactive item, then call Over
                if (interactible && m_CurrentInteractible != m_LastInteractible)
                {
                    if(m_Reticle)
                    {
                        m_Reticle.fillInTime(interactible);
                        m_Reticle.Show();
                    }
                    
                    interactible.ReticleEnter();
                }
                else if(interactible == null)
                {
                    if (m_Reticle)
                    {
                        m_Reticle.stopFilling();
                        m_Reticle.Hide();
                    }
                }

                // Deactive the last interactive item 
                if (interactible != m_LastInteractible)
                {
                    DeactiveLastInteractible();
                }

                m_LastInteractible = interactible;

                if (OnRaycasthit != null)
                    OnRaycasthit(hit);
                
            }
            else
            {
                // Nothing was hit, deactive the last interactive item.
                DeactiveLastInteractible();
                m_CurrentInteractible = null;

                // Position the reticle at default distance.
                if (m_Reticle)
                {
                    m_Reticle.stopFilling();
                    m_Reticle.Hide();
                }
            }
        }


        private void DeactiveLastInteractible()
        {
            if (m_LastInteractible == null)
                return;

            m_LastInteractible.ReticleExit();
            m_LastInteractible = null;
        }


        private void HandleUp()
        {
            if (m_CurrentInteractible != null)
                m_CurrentInteractible.MouseUp();
        }


        private void HandleDown()
        {
            if (m_CurrentInteractible != null)
                m_CurrentInteractible.MouseDown();
        }


        private void HandleClick()
        {
            if (m_CurrentInteractible != null)
                m_CurrentInteractible.MouseClick();
        }


        private void HandleDoubleClick()
        {
            if (m_CurrentInteractible != null)
                m_CurrentInteractible.MouseDoubleClick();

        }
    }
}