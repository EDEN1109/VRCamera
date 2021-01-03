using System;
using UnityEngine;
using UnityEngine.Events;

// TO DO : namespace 이름 변경
namespace m111001001.Handler
{
    // This class encapsulates all the input required for most VR games.
    // It has events that can be subscribed to by classes that need specific input.
    // This class must exist in every scene and so can be attached to the main
    // camera for ease.
    public class VRInput : MonoBehaviour
    {
        //Swipe directions
        public enum SwipeDirection
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT
        };


        public UnityEvent<SwipeDirection> OnSwipe;                // Called every frame passing in the swipe, including if there is no swipe.
        public UnityEvent OnMouseClick;                                // Called when Fire1 is released and it's not a double click.
        public UnityEvent OnMouseDown;                                 // Called when Fire1 is pressed.
        public UnityEvent OnMouseUp;                                   // Called when Fire1 is released.
        public UnityEvent OnMouseDoubleClick;                          // Called when a double click is detected.
        public UnityEvent OnCancel;                               // Called when Cancel is pressed.


        [SerializeField] private float doubleClickTime = 0.3f;    //The max time allowed between double clicks
        [SerializeField] private float swipeWidth = 0.3f;         //The width of a swipe

        
        private Vector2 mouseDownPosition;                        // The screen position of the mouse when Fire1 is pressed.
        private Vector2 mouseUpPosition;                          // The screen position of the mouse when Fire1 is released.
        private float lastMouseUpTime;                            // The time when Fire1 was last released.
        private float lastHorizontalValue;                        // The previous value of the horizontal axis used to detect keyboard swipes.
        private float lastVerticalValue;                          // The previous value of the vertical axis used to detect keyboard swipes.


        private void Update()
        {
            CheckInput();
        }


        private void CheckInput()
        {
            // Set the default swipe to be none.
            SwipeDirection swipe = SwipeDirection.NONE;

            if (Input.GetButtonDown("Fire1"))
            {
                // When Fire1 is pressed record the position of the mouse.
                mouseDownPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
                // If anything has subscribed to OnDown call it.
                if (OnMouseDown != null)
                    OnMouseDown.Invoke();
            }

            // This if statement is to gather information about the mouse when the button is up.
            if (Input.GetButtonUp ("Fire1"))
            {
                // When Fire1 is released record the position of the mouse.
                mouseUpPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

                // Detect the direction between the mouse positions when Fire1 is pressed and released.
                swipe = DetectSwipe ();
            }

            // If there was no swipe this frame from the mouse, check for a keyboard swipe.
            if (swipe == SwipeDirection.NONE)
                swipe = DetectKeyboardEmulatedSwipe();

            // If there are any subscribers to OnSwipe call it passing in the detected swipe.
            if (OnSwipe != null)
                OnSwipe.Invoke(swipe);

            // This if statement is to trigger events based on the information gathered before.
            if(Input.GetButtonUp ("Fire1"))
            {
                // If anything has subscribed to OnUp call it.
                if (OnMouseUp != null)
                    OnMouseUp.Invoke();

                // If the time between the last release of Fire1 and now is less
                // than the allowed double click time then it's a double click.
                if (Time.time - lastMouseUpTime < doubleClickTime)
                {
                    // If anything has subscribed to OnDoubleClick call it.
                    if (OnMouseDoubleClick != null)
                        OnMouseDoubleClick.Invoke();
                }
                else
                {
                    // If it's not a double click, it's a single click.
                    // If anything has subscribed to OnClick call it.
                    if (OnMouseClick != null)
                        OnMouseClick.Invoke();
                }

                // Record the time when Fire1 is released.
                lastMouseUpTime = Time.time;
            }

            // If the Cancel button is pressed and there are subscribers to OnCancel call it.
            if (Input.GetButtonDown("Cancel"))
            {
                if (OnCancel != null)
                    OnCancel.Invoke();
            }
        }


        private SwipeDirection DetectSwipe ()
        {
            // Get the direction from the mouse position when Fire1 is pressed to when it is released.
            Vector2 swipeData = (mouseUpPosition - mouseDownPosition).normalized;

            // If the direction of the swipe has a small width it is vertical.
            bool swipeIsVertical = Mathf.Abs (swipeData.x) < swipeWidth;

            // If the direction of the swipe has a small height it is horizontal.
            bool swipeIsHorizontal = Mathf.Abs(swipeData.y) < swipeWidth;

            // If the swipe has a positive y component and is vertical the swipe is up.
            if (swipeData.y > 0f && swipeIsVertical)
                return SwipeDirection.UP;

            // If the swipe has a negative y component and is vertical the swipe is down.
            if (swipeData.y < 0f && swipeIsVertical)
                return SwipeDirection.DOWN;

            // If the swipe has a positive x component and is horizontal the swipe is right.
            if (swipeData.x > 0f && swipeIsHorizontal)
                return SwipeDirection.RIGHT;

            // If the swipe has a negative x component and is vertical the swipe is left.
            if (swipeData.x < 0f && swipeIsHorizontal)
                return SwipeDirection.LEFT;

            // If the swipe meets none of these requirements there is no swipe.
            return SwipeDirection.NONE;
        }


        private SwipeDirection DetectKeyboardEmulatedSwipe ()
        {
            // Store the values for Horizontal and Vertical axes.
            float horizontal = Input.GetAxis ("Horizontal");
            float vertical = Input.GetAxis ("Vertical");

            // Store whether there was horizontal or vertical input before.
            bool noHorizontalInputPreviously = Mathf.Abs (lastHorizontalValue) < float.Epsilon;
            bool noVerticalInputPreviously = Mathf.Abs(lastVerticalValue) < float.Epsilon;

            // The last horizontal values are now the current ones.
            lastHorizontalValue = horizontal;
            lastVerticalValue = vertical;

            // If there is positive vertical input now and previously there wasn't the swipe is up.
            if (vertical > 0f && noVerticalInputPreviously)
                return SwipeDirection.UP;

            // If there is negative vertical input now and previously there wasn't the swipe is down.
            if (vertical < 0f && noVerticalInputPreviously)
                return SwipeDirection.DOWN;

            // If there is positive horizontal input now and previously there wasn't the swipe is right.
            if (horizontal > 0f && noHorizontalInputPreviously)
                return SwipeDirection.RIGHT;

            // If there is negative horizontal input now and previously there wasn't the swipe is left.
            if (horizontal < 0f && noHorizontalInputPreviously)
                return SwipeDirection.LEFT;

            // If the swipe meets none of these requirements there is no swipe.
            return SwipeDirection.NONE;
        }
        

        private void OnDestroy()
        {
            // Ensure that all events are unsubscribed when this is destroyed.
            OnSwipe = null;
            OnMouseClick = null;
            OnMouseDoubleClick = null;
            OnMouseDown = null;
            OnMouseUp = null;
        }
    }
}