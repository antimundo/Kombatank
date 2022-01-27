using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    [System.NonSerialized] public bool isReady = false;
    [System.NonSerialized] public int id;
    public int currentColor { get; private set; }
    [SerializeField] PlayerSkins skins;

    public void setColor(int newColor)
    {
        currentColor = newColor;
        if (currentColor >= skins.colors.Length) currentColor = 0;
        foreach (SpriteRenderer sr in transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>())
        {
            sr.color = skins.colors[currentColor];
        }
    }

}
