using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehaviour : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float gravity = 9.81f;
    public float chaseRange = 5.0f, speed = 4.0f;
    bool isGrounded;
    //Attacking----
    public float shootRange = 15;
    private float fireCounter;
    [SerializeField]
    private float fireRate = 0.75f;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;
    //-------
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Chase();
    }

    public void Chase()
    {
        Vector3 dir = (GameManager.player.transform.position - this.transform.position);
        if (IsInRange() && IsInView())
        {
            
            dir = GameManager.player.transform.position - transform.position;
            this.transform.LookAt(GameManager.player.transform);
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < shootRange)
            {
                this.GetComponent<Animator>().Play("Attack01");
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {

                    
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
            else
            {
                this.GetComponent<Animator>().Play("RunForwardBattle");
            }
            //Instantiate(bullet);
        }
        else
        {
            this.GetComponent<Animator>().Play("Idle_Battle");
           
            dir = Vector3.zero;
        }
        
       // dir = dir.normalized;
        Vector3 v = dir.normalized * speed * Time.deltaTime;
       // v = v.normalized;
        

        // this.GetComponent<Rigidbody>().velocity = dir * speed * Time.deltaTime;
        if (isGrounded)
        {
            v.y = 0;
        }
        else
        {
            v.y += (gravity * -2f);
        }
        this.GetComponent<Rigidbody>().velocity = v;// Mathf.Sqrt(JumpHeight * -2f * gravity);

        Debug.DrawRay(GameManager.player.transform.forward, GameManager.player.transform.forward, Color.red);
        Debug.DrawRay(this.transform.position, this.transform.position - GameManager.player.transform.position, Color.blue);
        

    }

    public bool IsInView()
    {
        float dot = Vector3.Dot(this.transform.forward, GameManager.player.transform.position - this.transform.position);
        
        return dot > 0 ? true : false;
    }

    public bool IsInRange()
    {
        return Vector3.Distance(this.transform.position, GameManager.player.transform.position) < chaseRange ? true : false;
    }
    

}
