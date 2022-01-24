using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadyButton : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            FindObjectOfType<PlayerSelectionScreen>().players[collision.gameObject.GetComponent<Bullet>().id].GetComponent<PlayerId>().isReady = true;
            FindObjectOfType<PlayerSelectionScreen>().DisplayInfo();
        }
    }
}
