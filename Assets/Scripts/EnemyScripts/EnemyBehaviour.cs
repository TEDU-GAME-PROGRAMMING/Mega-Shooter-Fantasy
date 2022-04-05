using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float gravity = 9.81f;
    public float chaseRange = 5.0f, speed = 4.0f;
    bool isGrounded;
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
            this.GetComponent<Animator>().Play("RunForwardBattle");
            dir = GameManager.player.transform.position - transform.position;
            this.transform.LookAt(GameManager.player.transform);

            //Instantiate(bullet);
        }
        else
        {
            dir = Vector3.zero;
        }
        
       // dir = dir.normalized;
        Vector3 v = dir * speed * Time.deltaTime;
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
