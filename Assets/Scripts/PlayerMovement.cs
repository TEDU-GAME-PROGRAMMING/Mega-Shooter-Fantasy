using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
   // public GameObject object1 ; 
    public float speed = 12f;
    public float gravity = -9.18f;
    public float JumpHeight = 3f; 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator anim;
    public bool isAttacking = false;
    public Vector3 velocity;

    public bool isGrounded;
    public bool canDoubleJump = true;


    // Update is called once per frame
    void Update()
    {
       


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded&& velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement of the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // v = sqrt(h * -2 * g)
            velocity.y = Mathf.Sqrt(JumpHeight *-2f*gravity);
        }

        //double jump
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            canDoubleJump = false;
        }


        if (isGrounded)
        {
            //double jump charge
            canDoubleJump = true;   
        }



        // dashing

        velocity.y += gravity * Time.deltaTime;
        // JUMP
        controller.Move(velocity* Time.deltaTime);
        attakcAnimation();

    }
    
     public async void attakcAnimation()
    {
        float timerRemaning = 0;
        
            isAttacking = true;
          // if (isAttacking)
            //{
            if (Input.GetMouseButtonDown(0))
            {
                timerRemaning += 0.05f ;

            }
           /* else
            {
                isAttacking = false;
            }
                //anim.GetComponent<Animator>().StopPlayback() ;
                
                
            }
            else
            {
                
            }*/
        if (timerRemaning>0)
        {
            anim.SetBool("isAttacking", true);
            timerRemaning -= Time.deltaTime;
            Debug.Log(timerRemaning);
        }
        else if(timerRemaning < 0)
        {
            anim.SetBool("isAttacking", false);
            Debug.Log(timerRemaning);
        }
       
    } 
}
