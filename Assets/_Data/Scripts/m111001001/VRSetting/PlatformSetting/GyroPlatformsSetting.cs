using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m111001001.Platforms
{
    public class GyroPlatformsSetting : PlatformsSetting
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        override protected void Update()
        {
            base.Update();

            GyroRotate();

            player.rotation = Quaternion.Euler(0, xAngle, 0);
            centerCamera.localRotation = Quaternion.Euler(-yAngle, 0, 0);
        }
        override protected void Init()
        {
            base.Init();

            xAngle = player.transform.rotation.eulerAngles.x;
            yAngle = centerCamera.transform.rotation.eulerAngles.y;

            Input.gyro.enabled = true;
        }

        protected void GyroRotate()
        {
            xAngle += -Input.gyro.rotationRateUnbiased.y;
            yAngle += Input.gyro.rotationRateUnbiased.x;
        }

    }
}
