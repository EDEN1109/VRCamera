using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] RectTransform vrBox;
    [SerializeField] Camera camera;
    private float screenX;
    private float screenY;

    private void Awake()
    {
        screenX = Screen.width / Screen.dpi / 2.54f;
        screenY = Screen.height / Screen.dpi ;
        vrBox.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, screenX);
        vrBox.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, screenY);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
