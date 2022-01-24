using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    public int id { get; private set; }

    public void DestroyBullet(int myId, float lifespan)
    {
        this.id = myId;
        StartCoroutine(DestroyBulletCoroutine(lifespan));
    }

    IEnumerator DestroyBulletCoroutine(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
