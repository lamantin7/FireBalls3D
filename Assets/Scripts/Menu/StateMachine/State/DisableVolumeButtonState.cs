using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVolumeButtonState : ConfigureVolumeButtonState
{
    protected override float VolumeLevel => -80.0f;
}
