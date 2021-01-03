using System;
using UnityEngine;
using UnityEngine.Events;

// TO DO : namespace 이름 변경
namespace m111001001.Interaction
{
    // This class should be added to any gameobject in the scene
    // that should react to input based on the user's gaze.
    // It contains events that can be subscribed to by classes that
    // need to know about input specifics to this gameobject.
    [RequireComponent(typeof(Collider))]
    public abstract class VRInteractive : MonoBehaviour
    {
        public bool canMouseClick = false;
        public UnityEvent OnReticleEnter;             // Called when the gaze moves over this object
        public UnityEvent OnReticleStay;         // Called when the gaze moves overring this object
        public UnityEvent OnReticleExit;              // Called when the gaze leaves this object
        public UnityEvent OnReticleFullFilled;         // Called when ring full filled
        public UnityEvent OnMouseClick;            // Called when click input is detected whilst the gaze is over this object.
        public UnityEvent OnMouseDoubleClick;      // Called when double click input is detected whilst the gaze is over this object.
        public UnityEvent OnMouseUp;               // Called when Fire1 is released whilst the gaze is over this object.
        public UnityEvent OnMouseDown;             // Called when Fire1 is pressed whilst the gaze is over this object.

        private float autoClickTime = 1f;
        private float clickTimerState = 0f;

        [HideInInspector] public bool clicked = false;
        [HideInInspector] public bool fullFilled = false;
        [HideInInspector] public bool isOver;
        

        virtual protected void Update()
        {
            if (canMouseClick && isOver && !clicked)
            {
                clickTimerState += Time.deltaTime;
                if (clickTimerState >= autoClickTime)
                {
                    MouseClick();
                }
            }

            if(isOver)
            {
                ReticleStay();
            }
        }

        public void setAutoClickTime(float time)
        {
            autoClickTime = time;
        }

        // The below functions are called by the VREyeRaycaster when the appropriate input is detected.
        // They in turn call the appropriate events should they have subscribers.
        public void ReticleEnter()
        {
            isOver = true;

            if (OnReticleEnter != null)
                OnReticleEnter.Invoke();
        }

        public void ReticleStay()
        {
            if (OnReticleStay != null)
                OnReticleStay.Invoke();
        }

        public void ReticleExit()
        {
            isOver = false;
            clicked = false;
            fullFilled = false;
            clickTimerState = 0f;

            if (OnReticleExit != null)
                OnReticleExit.Invoke();
        }

        public void ReticleFullFilled()
        {
            fullFilled = true;

            if (OnReticleFullFilled != null)
                OnReticleFullFilled.Invoke();
        }

        public void MouseClick()
        {
            clicked = true;

            if (OnMouseClick != null)
                OnMouseClick.Invoke();
        }


        public void MouseDoubleClick()
        {
            if (OnMouseDoubleClick != null)
                OnMouseDoubleClick.Invoke();
        }


        public void MouseUp()
        {
            if (OnMouseUp != null)
                OnMouseUp.Invoke();
        }


        public void MouseDown()
        {
            if (OnMouseDown != null)
                OnMouseDown.Invoke();
        }
    }
}