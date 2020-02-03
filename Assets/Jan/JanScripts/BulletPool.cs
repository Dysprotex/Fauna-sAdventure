
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public BulletBehaviour prefab;
    public BulletBehaviour noPrefab;
    public int initialPoolAmount = 100;
    List<BulletBehaviour> objectList;

    private void Awake()
    {
        objectList = new List<BulletBehaviour>();
        for (int i = 0; i < initialPoolAmount; i++)
        {
            AddObjectToPool();
        }
    }

    BulletBehaviour AddObjectToPool()
    {
        BulletBehaviour newBullet = Instantiate(prefab);
        newBullet.gameObject.SetActive(false);
        objectList.Add(newBullet);
        return newBullet;
    }

    /// <summary>
    /// Returns a reference to a BulletBehaviour component on a disable GameObject from the pool.
    /// </summary>
    /// <returns>A BulletBehaviour reference</returns>
    public BulletBehaviour GetObjectFromPool()
    {
        foreach (BulletBehaviour currentObject in objectList)
        {
            if (!currentObject.gameObject.activeSelf) {
                return currentObject;
            }
        }
        return AddObjectToPool();
    }

    BulletBehaviour Nothing()
    {
        BulletBehaviour noBullet = Instantiate(noPrefab);
        return noBullet;
    }
}
