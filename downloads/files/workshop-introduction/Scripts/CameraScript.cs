using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    [Header("Follow this player")]
	public Transform followPlayer;
    public bool followYPosition = false;


	void FixedUpdate() {
        float newY = (followYPosition) ? followPlayer.position.y : transform.position.y;
        transform.position = new Vector3(followPlayer.position.x, newY, transform.position.z);
        
        // you can also drag the camera object in the player object!
    }
}
