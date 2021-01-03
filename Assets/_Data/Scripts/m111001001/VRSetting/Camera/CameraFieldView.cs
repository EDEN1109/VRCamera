using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m111001001.CameraView
{
    public class CameraFieldView : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Wait());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);

            this.GetComponent<Camera>().fieldOfView = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().fieldOfView;
        }
    }
}
