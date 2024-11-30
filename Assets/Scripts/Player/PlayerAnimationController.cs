using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    //int isJumpingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        //isJumpingHash = Animator.StringToHash("isJumping");
    }


    void FixedUpdate()
    {
        bool isWaliking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        //bool isJumping = animator.GetBool(isJumpingHash);

        bool forwardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool movingPressed = (forwardPressed || backPressed || leftPressed || rightPressed);
        bool runPressed = Input.GetKey("left shift");
        //bool jumpPressed = Input.GetKey("space");

        if (!isWaliking && movingPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWaliking && !movingPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (runPressed && movingPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!runPressed || !movingPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
