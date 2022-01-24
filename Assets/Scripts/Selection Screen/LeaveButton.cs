using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeaveButton : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Bullet")
        {
            Destroy(FindObjectOfType<PlayerSelectionScreen>().players[collision.gameObject.GetComponent<Bullet>().id]);
        }
    }
}
