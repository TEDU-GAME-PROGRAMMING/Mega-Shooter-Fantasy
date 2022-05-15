using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMeshMeele : MonoBehaviour
{
    public Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public float shootRange = 15;

    public float chaseRange = 500.0f;


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

            navMeshAgent.destination = movePositionTransform.position;
            //navMeshAgent.speed = 3.5f;
            if (Vector3.Distance(transform.position, movePositionTransform.position) <= shootRange)
            {

                this.GetComponent<Animator>().Play("Attack01");

            }
            else
            {
                this.GetComponent<Animator>().Play("RunForwardBattle");
            }
        }
        else
        {

            //navMeshAgent.speed = 0;
            this.GetComponent<Animator>().Play("Idle_Battle");

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
