using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public enum EnemyState
{
    Roam,
    Follow,
    Attack
}

/*public enum EnemyState
{
    Roam,
    Follow,
    Attack
}*/

public class EnemySearch : MonoBehaviour
{
    // Start is called before the first frame update

    public Ally Ally => ally;
    [SerializeField] private Ally ally;
    [SerializeField] private LayerMask mask;

    private float attackRange = 2.0f, rayDist = 6.0f, stopDist = 6.0f;
    private Vector3 dest, dir;
    private Quaternion aimedRot;
    private GameObject target;
    private EnemyState state;

    /*
        public Team Team => _team;
        [SerializeField] private Team _team;
        [SerializeField] private LayerMask _layerMask;

        private float _a*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case EnemyState.Roam:
            {
                if (NeedsDestination())
                {
                    GetDestination();
                }
                    this.transform.rotation = aimedRot;
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                    var rayColor = IsPathBlocked() ? Color.red : Color.green;
                    Debug.DrawRay(this.transform.position, dir * rayDist, rayColor);

                    while(IsPathBlocked())
                    {
                        Debug.Log("Path blocked");
                        GetDestination();

                    }

                    var targetToAggro = CheckForAggro();
                    if(targetToAggro != null)
                    {
                        target = targetToAggro.GetComponent<EnemySearch>().gameObject;
                        state = EnemyState.Follow;
                    }
                    break;
                
            }

            case EnemyState.Follow:
            {
                if (target == null)
                {
                    state = EnemyState.Roam;
                    return;
                }

                break;
            }

            case EnemyState.Attack:
                {
                    if(target != null)
                    {
                        Destroy(target.gameObject);
                    }

                    state = EnemyState.Roam;

                    break;

                }



        }
    }

    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    private Transform CheckForAggro()
    {
        float aggroRadius = 5.0f;

        RaycastHit hit;
        
        var angle = this.transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;

        for(var i = 0; i < 24; i++)
        {
            if(Physics.Raycast(pos, direction, out hit, aggroRadius))
            {
                var drone = hit.collider.GetComponent<EnemySearch>();
                if(drone != null && drone.Ally != gameObject.GetComponent<EnemySearch>().Ally)
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return drone.transform;
                } else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * aggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(this.transform.position, dir);
        var hitSomething = Physics.Raycast(ray, rayDist, mask);
        //return hitSomething.Any();

        return false;
    
    }

    private bool NeedsDestination()
    {
        if(dest == Vector3.zero)
        {
            return true;
        }

        float distance = Vector3.Distance(this.transform.position, dest);
        if(distance <= stopDist)
        {
            return true;
        }

        return false;


    }

    private void GetDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) + new Vector3(Random.Range(-4.5f, 4.5f), 0f, Random.Range(-4.5f, 4.5f));
        dest = new Vector3(testPosition.x, 1f, testPosition.z);
        dir = Vector3.Normalize(dest - transform.position);
        dir = new Vector3(dir.x, 0f, dir.z);
        aimedRot = Quaternion.LookRotation(dir);
    }
}
