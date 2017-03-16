using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    [Tooltip("Game object that will be used to know where the camera is facing.")]
    public GameObject cameraAnchor;
    public KeyboardMouseConfig keyboardMouseConfig;
    public Vector3 direction;
    public bool holdingJump;
    public bool jumped;
    public bool targeted;
    public bool attacked;
    public Vector3 rotation;

    void Update()
    {
        this.SetDirection();
        this.SetRotation();
        this.SetJump();
        this.SetTargeting();
        this.SetAttack();
    }

    void SetDirection()
    {
        this.direction = Vector3.zero;

        if (Input.GetKey(this.keyboardMouseConfig.up))
        {
            this.direction += cameraAnchor.transform.forward;
        }
        else if (Input.GetKey(this.keyboardMouseConfig.down))
        {
            this.direction -= cameraAnchor.transform.forward;
        }

        if (Input.GetKey(this.keyboardMouseConfig.left))
        {
            this.direction -= cameraAnchor.transform.right;
        }
        else if (Input.GetKey(this.keyboardMouseConfig.right))
        {
            this.direction += cameraAnchor.transform.right;
        }
        this.direction = this.direction.normalized;
    }

    private void SetRotation()
    {
        float yaw = Input.GetAxis("Mouse X") * this.keyboardMouseConfig.mouseXSensitivity;
        float pitch = Input.GetAxis("Mouse Y") * this.keyboardMouseConfig.mouseYSensitivity;

        if (this.keyboardMouseConfig.invertY)
        {
            pitch *= -1;
        }

        this.rotation = new Vector3(yaw, pitch, 0f);
    }

    void SetJump()
    {
        jumped = Input.GetKeyDown(this.keyboardMouseConfig.jump);
        holdingJump = Input.GetKey(this.keyboardMouseConfig.jump);
    }

    void SetTargeting()
    {
        targeted = Input.GetKeyDown(this.keyboardMouseConfig.target);
    }

    void SetAttack()
    {
        attacked = Input.GetKey(this.keyboardMouseConfig.attack);
    }
}