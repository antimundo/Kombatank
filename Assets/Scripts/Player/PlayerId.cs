using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    [System.NonSerialized] public bool isReady = false;
    [System.NonSerialized] public int id;
    public int currentSkin { get; private set; }
    [SerializeField] PlayerSkins skins;
    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer wheels;

    public void setColor(int newSkin)
    {
        currentSkin = newSkin;
        if (currentSkin >= skins.skins.Length) currentSkin = 0;

        body.sprite = skins.skins[currentSkin].body;
        wheels.sprite = skins.skins[currentSkin].wheel;

        wheels.GetComponent<SpriteMask>().sprite = skins.skins[currentSkin].wheel;
    }

}
