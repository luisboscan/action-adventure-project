﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingCameraController : MonoBehaviour, ICameraController
{
    public Camera cameraComponent;
    public GameObject player;
    public float distanceBehindPlayer = 5f;
    public float verticalAngle = 45f;
    public float smoothDampTime = 0.2f;

    private Vector3 currentDampVelocity;
    private GameObject target;

    public void UpdateCameraState(Vector2 rotation)
    {
        Vector3 focusPoint = GetFocusPoint();
        cameraComponent.transform.LookAt(focusPoint);
        cameraComponent.transform.position = Vector3.SmoothDamp(cameraComponent.transform.position, GetNextPosition(focusPoint), ref currentDampVelocity, smoothDampTime);
    }

    private Vector3 GetFocusPoint()
    {
        // The focus point is the middle position between the target and the player
        return player.transform.position + (target.transform.position - player.transform.position);
    }

    public Vector3 GetNextPosition()
    {
        Vector3 focusPoint = GetFocusPoint();
        return GetNextPosition(focusPoint);
    }

    public void GetNextState(out Vector3 position, out Quaternion rotation)
    {
        Vector3 focusPoint = GetFocusPoint();
        position = GetNextPosition(focusPoint);
        Vector3 currentPosition = cameraComponent.transform.position;
        Quaternion currentRotation = cameraComponent.transform.rotation;
        cameraComponent.transform.position = position;
        cameraComponent.transform.LookAt(focusPoint);
        rotation = cameraComponent.transform.rotation;
        cameraComponent.transform.position = currentPosition;
        cameraComponent.transform.rotation = currentRotation;
    }

    private Vector3 GetNextPosition(Vector3 focusPoint)
    {
        Vector3 directionBehindPlayer = Vector3.Normalize(player.transform.position - focusPoint);
        // Move the camera vertically depending on the specified angle
        directionBehindPlayer.y = Mathf.Sin(verticalAngle * Mathf.Deg2Rad);
        Vector3 nextPosition = player.transform.position + (directionBehindPlayer * distanceBehindPlayer);
        return nextPosition;
    }

    public void Reset()
    {
        // No need to reset this type of camera
    }

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
