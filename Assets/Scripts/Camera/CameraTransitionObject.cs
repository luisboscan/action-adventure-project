using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CameraTransitionObject
{
    public ICameraController controllerToTransitionTo;
    public CameraStates stateToTransitionTo;

    public CameraTransitionObject(ICameraController controllerToTransitionTo, CameraStates stateToTransitionTo)
    {
        this.controllerToTransitionTo = controllerToTransitionTo;
        this.stateToTransitionTo = stateToTransitionTo;
    }
}
