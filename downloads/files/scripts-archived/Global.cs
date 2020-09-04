using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	// dit is een voorbeeld van een script dat aan een leeg gameobject in de scene gekoppeld wordt
	public string Gamename;

	void Start () {
		Debug.Log ("starting " + this.Gamename);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
