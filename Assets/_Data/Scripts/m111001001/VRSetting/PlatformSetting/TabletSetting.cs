using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m111001001.Platforms
{
    public class TabletSetting : GyroPlatformsSetting
    {
        [SerializeField] private float touchMoveSpeed = 1f;
        private float xAngleTemp;
        private float yAngleTemp;
        private Vector3 FirstPoint;
        private Vector3 SecondPoint;

        void Awake()
        {
        }

        void Start()
        {

        }

        override protected void Update()
        {
            base.Update();

            TouchRotate();
        }

        private void TouchRotate()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    FirstPoint = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + ((SecondPoint.x - FirstPoint.x) * 180 / Screen.width) * touchMoveSpeed;
                    yAngle = yAngleTemp + ((SecondPoint.y - FirstPoint.y) * 90 / Screen.height) * touchMoveSpeed;
                }
            }

        }
    }
}
