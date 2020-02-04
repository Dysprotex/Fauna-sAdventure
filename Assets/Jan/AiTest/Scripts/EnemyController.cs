using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public int damageAmount;
    bool knockback = false;
    Vector3 direction;

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
    void FixedUpdate()
    {
        if (knockback)
        {
            agent.velocity = direction * 8;
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
        
        direction = collision.transform.forward;
        StartCoroutine(KnockBack());

        if (damageReceiver != null)
        {
            damageReceiver.DoDamage(damageAmount);
        }

    }
    IEnumerator KnockBack()
    {
        knockback = true;
        agent.angularSpeed = 0;

        yield return new WaitForSeconds(0.2f);

        knockback = false;
        agent.angularSpeed = 150;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
