using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] wayPoints;
    int num = 0;

    public float minDistance;

    public bool rand = false;
    public bool go = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("Error");
        }
        else
        {
            UpdateNavMeshTarget();
            agent.isStopped = false;
        }
    }

    private void Update()
    {
        if (go)
        {
            if (agent.remainingDistance <= minDistance)
            {
                if (!rand)
                {
                    if(num + 1 == wayPoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = UnityEngine.Random.Range(0, wayPoints.Length);
                }

                UpdateNavMeshTarget();
                agent.isStopped = false;
            }
        }
    }

    private void UpdateNavMeshTarget()
    {
        agent.SetDestination(wayPoints[num].transform.position);
    }
}
