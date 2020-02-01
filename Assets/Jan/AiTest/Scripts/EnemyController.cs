using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public int damageAmount;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        var script = GetComponent<EnemyUI>();

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            script.enabled = false;
        }

        if(distance > lookRadius)
        {
            script.enabled = true;
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damageReceiver = collision.gameObject.GetComponentInParent<IDamagable>();

        if (damageReceiver != null)
        {
            damageReceiver.DoDamage(damageAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
