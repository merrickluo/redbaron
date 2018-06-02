using UnityEngine;

public abstract class Weapon : ScriptableObject {

    public float damage;
    public float speed;
    public float fireRate;

    public GameObject bulletPrefab;

    protected float nextFireTime = 0f;

    public void Reset() {
        nextFireTime = 0f;
    }

    protected bool ShouldFire() {
        if (Time.time < this.nextFireTime) {
            return false;
        }
        this.nextFireTime = Time.time + 1f / this.fireRate;
        return true;
    }

    public abstract void Fire(GameObject muzzle);
}
