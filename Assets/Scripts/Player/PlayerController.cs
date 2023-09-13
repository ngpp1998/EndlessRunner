using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float gravity = -20;
    private bool isSliding = false;
    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        animator.SetBool("gameStart", true);

        //increasing speed over time
        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.2f * Time.deltaTime;

        direction.z = forwardSpeed;

        animator.SetBool("grounded", controller.isGrounded);
        
        if (controller.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;

        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            //old code for game over when player hits obstacles
        }
    }

    private IEnumerator Slide()
    {
        animator.SetBool("sliding", true);
        isSliding = true;
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        float originalGravity = gravity;
        gravity *= 20f; //increases the gravity for faster descent during slide
        yield return new WaitForSeconds(0.8f);
        gravity = originalGravity; //restore the original gravity
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        isSliding = false;
        animator.SetBool("sliding", false);
    }
}
