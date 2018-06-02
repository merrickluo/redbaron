using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour {

    public Weapon weapon;

    private bool isShooting = false;

    public void StartShooting() {
        this.isShooting = true;
    }

    public void StopShooting() {
        this.isShooting = false;
    }

    void Start() {
        StartCoroutine(CheckShooting());
    }

    IEnumerator CheckShooting() {
        for (;;) {
            if (this.isShooting) {
                GameObject bullet = Instantiate(this.weapon.bullet,
                                                this.transform.position,
                                                Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = Vector2.up * this.weapon.speed;
            }
            yield return new WaitForSeconds(this.weapon.fireRate);
        }
    }
}
