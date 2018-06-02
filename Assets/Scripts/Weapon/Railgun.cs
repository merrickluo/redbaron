using UnityEngine;

[CreateAssetMenu(menuName="Weapon/Railgun")]
public class Railgun : Weapon {

    public override void Fire(GameObject muzzle) {
        if (!this.ShouldFire()) {
            return;
        }

        GameObject bullet = GameObject.Instantiate(this.bulletPrefab,
                                                   muzzle.transform.position,
                                                   Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.up * this.speed;
    }
}
