using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Weapon", menuName="Weapon")]
public class Weapon : ScriptableObject {

    public float damage;
    public GameObject bullet;

    public float speed;
    public float fireRate;
}
