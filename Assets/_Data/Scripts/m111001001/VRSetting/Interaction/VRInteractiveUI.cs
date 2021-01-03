using System;
using UnityEngine;

// TO DO : namespace 이름 변경
namespace m111001001.Interaction
{
    // This class should be added to any gameobject in the scene
    // that should react to input based on the user's gaze.
    // It contains events that can be subscribed to by classes that
    // need to know about input specifics to this gameobject.
    public class VRInteractiveUI : VRInteractive
    {
        override protected void Update()
        {
            base.Update();
        }
    }
}