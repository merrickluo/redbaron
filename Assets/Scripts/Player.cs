using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public float health = 200f;
    public float moveSpeed = 5f;

    public GameObject muzzle;
    public Weapon weapon;

    private Rigidbody2D rb;
    private Animator animator;

    private float invincibleTimer = 2;

    void Start() {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        // private variables must be reset
        this.weapon.Reset();
    }

    void Update() {
        if (Input.GetButton("Fire1")) {
            this.weapon.Fire(this.muzzle);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        Vector2 targePos = this.rb.position + movement * moveSpeed * Time.deltaTime;
        this.rb.MovePosition(targePos);

        if (this.invincibleTimer > 0) {
            this.invincibleTimer -= Time.deltaTime;
        } else {
            this.animator.SetBool("invincible", false);
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
}
