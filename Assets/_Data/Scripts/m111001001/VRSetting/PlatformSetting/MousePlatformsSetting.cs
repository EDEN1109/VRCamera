using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m111001001.Platforms
{
    public abstract class MousePlatformsSetting : PlatformsSetting
    {
        [SerializeField] private float rotSpeed = 100f;

        // Update is called once per frame
        override protected void Update()
        {
            base.Update();

            MouseRotate();
            CursorLockSetting();

            centerCamera.localRotation = Quaternion.Euler(-yAngle, 0, 0);
            player.rotation = Quaternion.Euler(0, xAngle, 0);
        }

        override protected void Init()
        {
            base.Init();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected void MouseRotate()
        {
            xAngle += Input.GetAxis("Mouse X") * Time.smoothDeltaTime * rotSpeed;
            yAngle += Input.GetAxis("Mouse Y") * Time.smoothDeltaTime * rotSpeed;
        }
        protected void CursorLockSetting()
        {
            if (Cursor.visible && Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
