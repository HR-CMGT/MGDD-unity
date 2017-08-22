using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// verander private naar public om in de editor te kunnen tweaken met de waarden
	private Vector2 Speed = new Vector2(-1f,0);

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Speed;
	}
		
}
