using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    Collider[] colliders;

    public int damageAmount = 1;

    public float initialVelocity = 100f;
    public float lifeTime = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        colliders = GetComponentsInChildren<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damageReceiver = collision.gameObject.GetComponentInParent<IDamagable>();

       /* if(gameObject.layer == 12)
        {
            if(collision.gameObject.layer == 9)
            {
                return;
            }
        }*/

        if (damageReceiver != null)
        {
            damageReceiver.DoDamage(damageAmount);
        }

        DisableSelf();
    }

    public void Fire(Vector3 inheritedVelocity, int layerId)
    {
        rb.velocity = inheritedVelocity + transform.forward * initialVelocity;

        // change bullet layer
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].gameObject.layer = layerId;
        }

        Invoke("DisableSelf", lifeTime);
    }

    void DisableSelf()
    {
        CancelInvoke("DisableSelf");
        gameObject.SetActive(false);
    }
}
