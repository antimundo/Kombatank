using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    [System.NonSerialized] public int id;

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
