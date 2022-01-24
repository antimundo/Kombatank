using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    [System.NonSerialized] public bool isReady = false;
    [System.NonSerialized] public int id;
    [System.NonSerialized] public int currentColor;
    [SerializeField] PlayerSkins skins;

    public void setColor(int newColor)
    {
        currentColor = newColor;
        if (currentColor >= skins.colors.Length) currentColor = 0;
        transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = skins.colors[currentColor];
    }

}
