using UnityEngine;
using UnityEngine.UI;
using m111001001.Interaction;

// The reticle is a small point at the centre of the screen.
// It is used as a visual aid for aiming. The position of the
// reticle is either at a default position in space or on the
// surface of a VRInteractiveItem as determined by the VREyeRaycaster.


// TO DO : namespace 이름 변경
namespace m111001001.Handler
{
    public class Reticle : MonoBehaviour
    {
        [SerializeField] public bool isVR = false;
        [SerializeField] public Transform[] m_Dots;                    // 0 is Left, 1 is Right
        [SerializeField] private Image[] m_Images;                     // Reference to the image component that represents the reticles. 0 is Left, 1 is Right
        [SerializeField] private float timeToFilled = 3f;
        [SerializeField] private float reticleX = 150f;
        [SerializeField] private float reticleY = -20f;

        [HideInInspector] public VRInteractive interactive;
        [HideInInspector] public bool isFilled = false;
        private bool filling = false;


        private void Awake()
        {
            if (isVR)
            {
                SetReticlePosition();
            }
        }

        public void Hide()
        {
            Debug.Log("Hiding image");
            for (int i = 0; i < m_Dots.Length; i++)
            {
                m_Images[i].gameObject.SetActive(false);
            }
        }

        public void Show()
        {
            Debug.Log("Showing image");
            for (int i = 0; i < m_Dots.Length; i++)
            {
                m_Images[i].gameObject.SetActive(true);
            }
        }

        public void fillInTime(VRInteractive interactive)
        {
            for (int i = 0; i < m_Images.Length; i++)
            {
                m_Images[i].fillAmount = 0;
            }
            isFilled = false;
            filling = true;
            this.interactive = interactive;
        }

        public void stopFilling()
        {
            filling = false;
            isFilled = false;
            interactive = null;
            for (int i = 0; i < m_Images.Length; i++)
            {
                m_Images[i].fillAmount = 0;
            }
        }

        private void Update()
        {
            if (filling)
            {
                for (int i = 0; i < m_Images.Length; i++)
                {
                    m_Images[i].fillAmount += Time.deltaTime / timeToFilled;

                    if (m_Images[i].fillAmount >= 1f)
                    {
                        m_Images[i].fillAmount = 0f;
                        isFilled = true;
                    }
                }
                if (isFilled)
                {
                    interactive.ReticleFullFilled();
                    filling = false;
                }
            }
        }

        private void SetReticlePosition()
        {
            m_Dots[0].localPosition = new Vector3(-reticleX, reticleY, 0);
            m_Dots[1].localPosition = new Vector3(reticleX, reticleY, 0);
        }
    }
}
