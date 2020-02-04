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
        if (Time.timeScale <= 0) { return; }
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
