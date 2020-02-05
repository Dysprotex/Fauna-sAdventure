using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
    IInputReceiver[] inputReceivers;

    public float lookRadius = 10f;
    public int damageAmount;

    float timer = 0;
    float coolDown = 1f;

    Transform target;
    NavMeshAgent agent;

    bool knockback = false;
    Vector3 direction;

    void Start()
    {
        inputReceivers = GetComponentsInChildren<IInputReceiver>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(target.position, transform.position);
        var script = GetComponent<EnemyUI>();

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            Act();
            script.enabled = false;
        }
        if (distance <= agent.stoppingDistance)
        {
            agent.transform.LookAt(target.position);
            Act();
        }

        if (distance > lookRadius)
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

    public void Act()
    {
        if(timer >= coolDown)
        {
            for (int j = 0; j < inputReceivers.Length; j++)
            {
                inputReceivers[j].OnFireDown();
            }

            Resettimer();
        }
    }

    void Resettimer()
    {
        timer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damageReceiver = collision.gameObject.GetComponentInParent<IDamagable>();

        direction = collision.transform.forward * 2;
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
