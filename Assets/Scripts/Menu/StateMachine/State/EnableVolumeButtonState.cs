using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine
{
    public class EnableVolumeButtonState : ConfigureVolumeButtonState
    {
        protected override float VolumeLevel => 0.0f;
    }
}
