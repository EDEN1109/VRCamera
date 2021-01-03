using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTest : MonoBehaviour
{
    public void OnRecticleEnterTest()
    {
        Debug.Log("OnRecticleEnter");
    }
    public void OnRecticleStayTest()
    {
        Debug.Log("OnRecticleStay");
    }
    public void OnRecticleExitTest()
    {
        Debug.Log("OnRecticleExit");
    }
    public void OnRecticleFullFilledTest()
    {
        Debug.Log("OnRecticleFullFilled");
    }
    public void OnMouseClickTest()
    {
        Debug.Log("OnMouseClick");
    }
    public void OnMouseDoubleClickTest()
    {
        Debug.Log("OnMouseDoubleClick");
    }
    public void OnMouseUpTest()
    {
        Debug.Log("OnMouseUp");
    }
    public void OnMouseDownTest()
    {
        Debug.Log("OnMouseDown");
    }
}
