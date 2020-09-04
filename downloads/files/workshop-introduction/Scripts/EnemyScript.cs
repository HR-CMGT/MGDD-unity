using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [Header("Snelheid")]
    public float Speed;
    private float currentSpeed;
    private Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0F;
	}

	void OnBecameVisible() {
        currentSpeed = Speed;
    }

    void FixedUpdate() {
		rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        if (transform.position.x < -12 || transform.position.y < -8) {
            Destroy(gameObject);
        }
	}
}
