using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWaliking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        //bool backPressed = Input.GetKey("s");
        //bool leftPressed = Input.GetKey("a");
        //bool rightPressed = Input.GetKey("d");
        //bool movePressed = (forwardPressed || backPressed || leftPressed || rightPressed);
        bool runPressed = Input.GetKey("left shift");
        if (!isWaliking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWaliking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (!isRunning && (runPressed && forwardPressed)) {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!runPressed || !forwardPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
