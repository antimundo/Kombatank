using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovenet : MonoBehaviour
{
    [SerializeField] GameObject wheelSprite;
    [SerializeField] Rigidbody2D rb;

    private void FixedUpdate()
    {
        Vector2 currentPosition = wheelSprite.transform.position;
        //currentPosition.y -= (rb.velocity.y * 0.02f);
        //currentPosition.x -= (rb.velocity.x * 0.02f);
        wheelSprite.transform.position = currentPosition;
    }
}
