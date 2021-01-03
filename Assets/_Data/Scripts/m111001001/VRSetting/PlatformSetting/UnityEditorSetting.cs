using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

namespace m111001001.Platforms
{
    public class UnityEditorSetting : MousePlatformsSetting
    {
        [SerializeField] private float moveSpeed = 5f;

        // Update is called once per frame
        override protected void Update()
        {
            base.Update();

            PlayerMove();
        }

        private void PlayerMove()
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.Translate(Vector3.forward * Time.smoothDeltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.Translate(Vector3.back * Time.smoothDeltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.Translate(Vector3.left * Time.smoothDeltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.Translate(Vector3.right * Time.smoothDeltaTime * moveSpeed);
            }
        }
    }
}
