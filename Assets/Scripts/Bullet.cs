using UnityEngine;

public class Bullet : MonoBehaviour {

    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
