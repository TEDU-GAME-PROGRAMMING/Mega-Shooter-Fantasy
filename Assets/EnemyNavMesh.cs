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
            if (Vector3.Distance(transform.position, movePositionTransform.position) <= shootRange)
            {
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
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
