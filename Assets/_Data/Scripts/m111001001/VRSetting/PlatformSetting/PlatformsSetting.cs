using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TO DO : namespace 이름 변경
namespace m111001001.Platforms
{
    public class PlatformsSetting : MonoBehaviour
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected Transform centerCamera;
        protected float xAngle;
        protected float yAngle;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        virtual protected void Update()
        {
            if (player == null || centerCamera == null)
            {
                Init();
            }
        }

        virtual protected void Init()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            centerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }
}
