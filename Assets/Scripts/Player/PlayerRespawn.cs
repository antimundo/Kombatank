using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] GameObject Sprite;
    public bool isAlive { get; private set; } = true;

    // Input events
    PlayerShooting playerShooting;

    private void Update()
    {
        if (!isAlive && playerShooting.isShooting == 1)
        {
            respawn();
        }
    }

    void Start()
    {
        GetComponent<PlayerHealth>().OnDeath += die;
        playerShooting = GetComponent<PlayerShooting>();
    }

    private void die(object sender, System.EventArgs e)
    {
        isAlive = false;
        Sprite.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void respawn()
    {
        transform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        isAlive = true;
        Sprite.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
