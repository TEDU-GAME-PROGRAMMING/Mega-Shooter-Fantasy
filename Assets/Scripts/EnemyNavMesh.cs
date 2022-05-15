using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMesh : MonoBehaviour
{
    public Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public float shootRange = 15;
    private float fireCounter;
    [SerializeField]
    private float fireRate = 0.75f;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;
    public float chaseRange = 500.0f;
    public Animator anim;

    //---DENEME
    public ParticleSystem muzzleFlash;
    //-------


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
       // navMeshAgent.destination = movePositionTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.destination = movePositionTransform.position;
        if (IsInRange() && IsInView())
         {
            if (anim !=null)
            {
                foreach(AnimatorControllerParameter state in anim.parameters)
                {
                    if(state.name == "Walk_Anim")
                    {
                        anim.SetBool("Walk_Anim", true);
                    }
                    else if (state.name == "Run")
                    {
                        anim.SetBool("Run", true);
                    }
                }

                
                
                

            }
             navMeshAgent.destination = movePositionTransform.position;
             navMeshAgent.speed = 3.5f;
            if (Vector3.Distance(transform.position, movePositionTransform.position) <= shootRange)
            {
                //navMeshAgent.speed = 3.5f;
                //this.GetComponent<Animator>().Play("Attack01");
               
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    
                    fireCounter = fireRate;
                    if (muzzleFlash !=null)
                    {
                        muzzleFlash.Play();
                    }
                    
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
            else
            {
                //this.GetComponent<Animator>().Play("RunForwardBattle");
            }
        }
        else
        {
            if (anim != null)
            {
                navMeshAgent.speed = 0;

                foreach (AnimatorControllerParameter state in anim.parameters)
                {
                    if (state.name == "Walk_Anim")
                    {
                        anim.SetBool("Walk_Anim", false);
                    }
                    else if (state.name == "Run")
                    {
                        anim.SetBool("Run", false);
                    }
                }

                //this.GetComponent<Animator>().Play("Idle_Battle");
            }
        }
    }
    public bool IsInRange()
    {
        return Vector3.Distance(this.transform.position, GameManager.player.transform.position) < chaseRange ? true : false;
    }
    public bool IsInView()
    {
        float dot = Vector3.Dot(this.transform.forward, GameManager.player.transform.position - this.transform.position);

        return dot > 0 ? true : false;
    }
}
