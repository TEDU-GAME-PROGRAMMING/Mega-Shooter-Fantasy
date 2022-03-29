using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
   // public GameObject object1 ; 

    public Vector3 velocity;
    public float speed = 12f;
    public float gravity = -9.18f;

    public float JumpHeight = 3f; 
    public bool canDoubleJump = true;

    public Animator anim;
    public bool isAttacking = false;
    
    public Transform groundCheck;
    public bool isGrounded;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public float parachuteResistance = -1200f; //up to 900-1000 with skill
    public bool isParachuteOn = false;

    public Image healthImage;
    public float healthMax = 100;
    //TODO add get setter
    public float healthCurrent;

    //TODO solve bugs: Near the muontain velocity Y decreases, => increase the number of ground check objects
    //TODO solve bugs: when player top of the squirrel, velocity Y decreases => ?
    private void Start()
    {
         healthCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateUI();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Movement of the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            //TODO make it below equation += somehow / discuss with the team
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        //double jump
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump && !isParachuteOn)
        {
            //TODO make it below equation += somehow / discuss with the team
            //1- jetpack velocity Y problem
            //2- serial jump do not affect velocity problem
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            canDoubleJump = false;
        }


        //parachute
        //no need !isGrounded
        if (Input.GetKeyDown(KeyCode.P) && !isGrounded && velocity.y < 0)
        {
            //toggle parachute (on/off)
            if(!isParachuteOn)
            {
                isParachuteOn = true;
            }
            else
            {
                isParachuteOn = false;
            } 
        }


        if (isGrounded)
        {
            //double jump charge
            canDoubleJump = true;
            //turn off parachute
            isParachuteOn = false;
        }

        // dashing

        //parachute
        if (isParachuteOn)
        {
            //fixed gliding speed 
            velocity.y = (gravity + parachuteResistance) * Time.deltaTime;

        } 
        else if(isGrounded && velocity.y <= 0)
        {
            //if character is on the ground, set velocity Y to 0
            velocity.y = 0;
        }
        else
        {
            //falling
            velocity.y += gravity * Time.deltaTime;
        }
        
        // JUMP
        controller.Move(velocity* Time.deltaTime);
        //attakcAnimation();

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

    public void UpdateUI()
    {
        if(healthImage != null)
        {
            healthImage.fillAmount = healthCurrent / healthMax;
        }
        

    }
}
