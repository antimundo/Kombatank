using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public float force = 5;
    public float lifespan = 1;
    public float cooldown = 1;
    public int ammo = 1;
    public GameObject bullet;
}
