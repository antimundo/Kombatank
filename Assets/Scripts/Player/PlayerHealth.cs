using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    public event EventHandler OnDeath;
    int health;

    void Start()
    {
        health = MaxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet") {


            if (collision.gameObject.GetComponent<Bullet>().id != GetComponent<PlayerId>().id)
            {
                Destroy(collision.gameObject);

                health--;
            }

            if (health <= 0)
            {
                OnDeath?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
