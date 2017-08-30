using UnityEngine;
using System.Collections;

public class MoveLink : MonoBehaviour {

	public float moveSpeed = 3f;

	void Update() {
		// move link
		Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

		// pass horizontal movement to the animator
		GetComponent<Animator>().SetFloat("speed", dir.x);
	}
}
