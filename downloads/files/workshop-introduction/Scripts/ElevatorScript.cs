using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{

	[Header ("Elevator Movement")]
	public float Speed = 5f;
	public float Distance = 2f;
	public bool MoveVertical = true;

	private Vector2 startPosition;
	private float counter;

	void Start () {
		startPosition = transform.position;
	}

    void FixedUpdate() {
        counter += Speed / 200;
        float pos = Mathf.Sin(counter) * Distance;

        if (MoveVertical) {
            transform.position = new Vector2(startPosition.x, startPosition.y + pos);
        } else {
            transform.position = new Vector2(startPosition.x + pos, startPosition.y);
        }
    }
}
