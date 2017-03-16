using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingCameraStateBehaviour : StateBehaviour<CameraStates>
{
    public PlayerInput playerInput;
    public CameraStateMachine stateMachine;
    public GameObject player;

    public override CameraStates GetState()
    {
        return CameraStates.Targeting;
    }

    public override StateMachine<CameraStates> GetStateMachine()
    {
        return stateMachine;
    }

    public override void UpdateState()
    {
        stateMachine.RenderTargetingSprite(stateMachine.targetingCameraController.Target);
        GameObject target = stateMachine.targetingCameraController.Target;
        if (target == null || !stateMachine.targetTriggerArea.IsTargetInRange(target))
        {
            stateMachine.ChangeState(CameraStates.PreIdle);
        }
    }

    public override void FixedUpdateState()
    {
        stateMachine.targetingCameraController.UpdateCameraState(playerInput.rotation);
        player.transform.LookAt(stateMachine.targetingCameraController.Target.transform);
    }

    public override bool CanEnterState()
    {
        GameObject nextAvailableTarget = stateMachine.targetTriggerArea.getNextTarget();
        return nextAvailableTarget != null && stateMachine.State != CameraStates.Targeting;
    }
}
