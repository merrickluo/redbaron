using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Bullet") {
            Destroy(col.gameObject);
            health -= 20;
        }

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
