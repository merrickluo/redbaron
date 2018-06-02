using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Weapon/Shotgun")]
public class Shotgun : Weapon {

    public override void Fire(GameObject muzzle) {
        if (!this.ShouldFire()) {
            return;
        }

        GameObject cBullet = GameObject.Instantiate(this.bulletPrefab,
                                                   muzzle.transform.position,
                                                   Quaternion.identity);
        Rigidbody2D bulletRb = cBullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.up * this.speed;

        Quaternion lRotate = Quaternion.Euler(0, 0, 45);
        GameObject lBullet = GameObject.Instantiate(this.bulletPrefab,
                                                    muzzle.transform.position,
                                                    lRotate);
        Rigidbody2D bulletRb2 = lBullet.GetComponent<Rigidbody2D>();
        bulletRb2.velocity = this.speed * (Vector2.left + Vector2.up);

        Quaternion rRotate = Quaternion.Euler(0, 0, -45);
        GameObject rBullet = GameObject.Instantiate(this.bulletPrefab,
                                                    muzzle.transform.position,
                                                    rRotate);
        Rigidbody2D bulletRb3 = rBullet.GetComponent<Rigidbody2D>();
        bulletRb3.velocity = this.speed * (Vector2.right + Vector2.up);
    }
}
