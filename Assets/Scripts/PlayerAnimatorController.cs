using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    public Animator animator;
    public GroundCheck groundCheck;
    public CharacterMovement characterMovement;

    void Update () {
        bool grounded = groundCheck.IsGrounded;
        animator.SetBool("IsJumping", !groundCheck.IsGrounded);
        animator.SetBool("IsWalking", characterMovement.IsMoving);
    }
}
