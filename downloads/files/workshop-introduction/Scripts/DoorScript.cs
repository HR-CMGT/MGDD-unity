using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class DoorScript : MonoBehaviour {
    [Header("Next level")]
    [SerializeField] public string scenePath;
    private bool playerHitsDoor = false;
    private Keyboard kb;

    void Start(){
        kb = InputSystem.GetDevice<Keyboard>();
    }

	void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player") {
		    playerHitsDoor = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            playerHitsDoor = false;
        }
    }

    void Update(){
        // als UParrow is ingedrukt activeert de deur 
        if (playerHitsDoor && kb.upArrowKey.wasPressedThisFrame) {
            SceneManager.LoadScene(scenePath);
        }
    }
}
