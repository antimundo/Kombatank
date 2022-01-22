using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    [SerializeField] GameObject tank;

    void Start()
    {
        Instantiate(tank, transform);
    }

}
