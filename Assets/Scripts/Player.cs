using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public float health = 200f;
    public float moveSpeed = 5f;

    public GameObject gun;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    private Animator animator;

    private float invincibleTimer = 2;
    private bool isShooting = false;

    void Start() {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        StartCoroutine(CheckShooting());
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical)
            * moveSpeed * Time.deltaTime;
        this.rb.MovePosition(this.rb.position + movement);

        if (this.invincibleTimer > 0) {
            this.invincibleTimer -= Time.deltaTime;
        } else {
            this.animator.SetBool("invincible", false);
        }

        if (Input.GetButtonDown("Fire1")) {
            this.isShooting = true;
        }

        if (Input.GetButtonUp("Fire1")) {
            this.isShooting = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Enemy" && this.invincibleTimer <= 0) {
            // this.health -= 100;
            Debug.Log("Player been hit!");
            this.invincibleTimer = 2;
            this.animator.SetBool("invincible", true);
        }

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    IEnumerator CheckShooting() {
        for (;;) {
            if (this.isShooting) {
                GameObject bullet = Instantiate(this.bulletPrefab,
                                                this.gun.transform.position,
                                                Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = Vector2.up * 10f;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }
}
