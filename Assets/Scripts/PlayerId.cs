using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    [SerializeField] Color32[] color;
    static int idCount = 0;
    static bool[] idPicked = new bool[4];

    public int id { get; private set; }

    void Start()
    {
        AsignId();
        GetComponent<PlayerHealth>().OnDeath += releaseIdFree; ;

        transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = color[id];
    }

    private void releaseIdFree(object sender, EventArgs e)
    {
        idPicked[id] = false;
    }

    private void AsignId()
    {
        do
        {
            id = idCount;

            idCount++;
            if (idCount >= color.Length)
            {
                idCount = 0;
            }
        } while (idPicked[id]);

        idPicked[id] = true;
    }

}
