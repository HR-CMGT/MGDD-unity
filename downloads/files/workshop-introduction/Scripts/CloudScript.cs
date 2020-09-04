using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

	[Header("Snelheid naar links")]
    [Tooltip("Hoe snel naar links bewegen")]
    public float Speed = 1f;

    [Header("Schermrand")]
    [Tooltip("Binnen deze grens blijven")]
    public float leftBounds = -8f;
    public float rightBounds = 8f;

    void Start() {

    }

    void Update() {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);

        if(transform.position.x < leftBounds) {
            transform.position = new Vector3(rightBounds + 0.5f, transform.position.y, 0);
        }

    }
}
