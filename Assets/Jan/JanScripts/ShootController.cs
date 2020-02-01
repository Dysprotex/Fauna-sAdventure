using UnityEngine;

public class ShootController : MonoBehaviour, IInputReceiver
{
    public BulletPool bulletPool;
    public Transform cannonTransform;

    public int bulletLayerId;

    public float HInput { set { } }
    public float VInput { set { } }

    public void OnFireDown()
    {
        Shoot();
    }

    void Shoot()
    {
        BulletBehaviour newBullet = bulletPool.GetObjectFromPool();
        newBullet.transform.SetPositionAndRotation(cannonTransform.position, cannonTransform.rotation);

        // TODO: apply ship velocity to bullet?
        newBullet.Fire(Vector3.zero, bulletLayerId);

        newBullet.gameObject.SetActive(true);
    }
}
