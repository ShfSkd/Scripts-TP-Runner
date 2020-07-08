using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity=-20f;

    private CharacterController controller;
    private Vector3 dir=Vector3.zero;

    Animator animator;

    private bool isSliding;
    
    private int desierdLane = 1;//0-Left 1:middle 2:right

    public float laneDistance = 4f;// The distance between two lanes
    public bool isGrounded; 
    public Transform groundCheak;
    public LayerMask groundLayer;
    public float maxSpeed;
  


    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!PlayerGameManager.isGameStarted)
            return;

        // Increase Speed 
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.2f * Time.deltaTime;
            maxSpeed += 0.3f * Time.deltaTime;
        }
            
        

        animator.SetBool("IsGameStarted", true);
        dir.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheak.position, 1f, groundLayer);
        animator.SetBool("Grounded",isGrounded);


        if (controller.isGrounded)
        {
            dir.y = -1;
            if (SwipeManager.instance.SwipeUp)
            {
                Jump();
            }
        }
        else
        {
            dir.y += gravity * Time.deltaTime; ;
        }

        if (SwipeManager.instance.SwipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.instance.SwipeRigth)
            desierdLane++;
        else if (desierdLane == 3)
            desierdLane = 2;


        if (SwipeManager.instance.SwipeLeft)
            desierdLane--;
        else if (desierdLane == -1)
            desierdLane = 1 ;

        controller.Move(dir * Time.deltaTime);
        // Calculate the next target position
        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desierdLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }
        else if (desierdLane==2)
        {
            targetPos += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, 80f*Time.deltaTime);
        controller.center = controller.center;
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerGameManager.gameOver = true;
            FindObjectOfType<SoundManager>().StopSound("MainTheme"); 
            FindObjectOfType<SoundManager>().PlaySound("GameOver");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("IsSliding", true);

        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        controller.center = Vector3.zero;
        controller.height = 2;

        animator.SetBool("IsSliding", false);
        isSliding = false;
    }
}
