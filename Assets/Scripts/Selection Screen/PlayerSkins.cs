using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSkins : ScriptableObject
{
    [SerializeField] public Skin[] skins;
}

[Serializable]
public class Skin
{
    [SerializeField] public Sprite body;
    [SerializeField] public Sprite wheel;
}
