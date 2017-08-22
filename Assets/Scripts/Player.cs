using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// verander private naar public om in de editor te kunnen tweaken met de waarden
	private float Speed = 2f;

	void OnCollisionEnter2D(Collision2D collided){
		// de variabele collided verwijst naar het object waar we mee botsen
		//Destroy(collided.gameObject);

		// de variable gameObject verwijst naar DIT gameobject - het schip
		//Destroy(gameObject);
	} 


	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2(Input.GetAxis("Horizontal")*Speed, Input.GetAxis("Vertical")*Speed);
	}

}
