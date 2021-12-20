using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting settings")]
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float cooldown = 1f;
    [SerializeField] float force = 5f;
    [SerializeField] float lifespan = 1f;

    // Local variables
    bool canShoot;
    float nextShot;
    Coroutine myCoroutine;

    void Update()
    {
        canShoot = Time.time > nextShot;

        if (Input.GetKey(KeyCode.Space) && canShoot == true)
        {
            // bullet instantiate
            GameObject thisBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            StartCoroutine(DestroyBullet(thisBullet, lifespan));

            // impulse
            Rigidbody2D rb = thisBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);

            // cooldon
            nextShot = Time.time + cooldown;
            canShoot = false;
        }
    }

    IEnumerator DestroyBullet(GameObject nowBullet, float lifespan)
    {
        yield return new WaitForSeconds(lifespan);

        if (nowBullet == null) yield break;
        Destroy(nowBullet);
    }
}
