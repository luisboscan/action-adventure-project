using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour, ICameraController
{
    public Camera cameraComponent;
    public GameObject target;
    public GameObject cameraAnchor;
    public GameObject parentX;
    public GameObject parentY;
    public float maxAngleY = 50f;
    public float minAngleY = 355f;

    public void UpdateCameraState(Vector2 rotation)
    {
        parentX.transform.rotation *= Quaternion.Euler(0f, rotation.x, 0f);
        // limit y
        parentY.transform.rotation *= Quaternion.Euler(rotation.y, 0f, 0f);
        Vector3 angles = parentY.transform.localRotation.eulerAngles;
        // clamp Y
        if (angles.x > maxAngleY && angles.x < 180)
        {
            angles = new Vector3(maxAngleY, 0, 0);
        }
        else if (angles.x < minAngleY && angles.x > 180)
        {
            angles = new Vector3(minAngleY, 0, 0);
        }
        parentY.transform.localRotation = Quaternion.Euler(angles);
        // update camera
        cameraComponent.transform.rotation = cameraAnchor.transform.rotation;
        cameraComponent.transform.position = cameraAnchor.transform.position;
    }

    public void Reset()
    {
        parentY.transform.localRotation = Quaternion.Euler(0, 0, 0);
        parentX.transform.rotation = Quaternion.Euler(0, cameraComponent.transform.eulerAngles.y, 0);
    }

    public void GetNextState(out Vector3 position, out Quaternion rotation)
    {
        position = cameraAnchor.transform.position;
        rotation = cameraAnchor.transform.rotation;
    }
}