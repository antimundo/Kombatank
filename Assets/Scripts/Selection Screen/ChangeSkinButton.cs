using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinButton : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            //FindObjectOfType<PlayerSelectionScreen>().players[collision.gameObject.GetComponent<Bullet>().id].GetComponent<PlayerId>().setColor(
            //    FindObjectOfType<PlayerSelectionScreen>().colors);
            FindObjectOfType<PlayerId>().setColor(++FindObjectOfType<PlayerId>().currentColor);
        }
    }
}
