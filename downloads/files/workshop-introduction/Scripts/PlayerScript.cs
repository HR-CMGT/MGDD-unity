using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement")]
    public float jumpForce = 8f;
    public float walkSpeed = 4f;

    [Header("Audio")]
    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip enemySound;
    public AudioClip backgroundMusic;
    public bool playBackgroundMusic = false;
    public float musicVolume = 0.8f;

    [Header("Collision")]
    public Transform GroundCheck;
    public LayerMask checkTheseLayers;

    private Rigidbody2D rb;
    private MarioControls marioControls;
    private AudioSource currentSoundSource;

    void Awake() {
        marioControls = new MarioControls();
        rb = GetComponent<Rigidbody2D>();
        marioControls.Player.Jump.performed += ctx => Jump();
        //marioControls.Player.Move.performed += ctx => Move(ctx.ReadValue<float>());

        currentSoundSource = GetComponent<AudioSource>();

        if (playBackgroundMusic) {
            currentSoundSource.clip = backgroundMusic;
            currentSoundSource.volume = musicVolume;
            currentSoundSource.loop = true;
            currentSoundSource.Play();
        }
    }

    void Update() {
        
    }

    private void Jump(){
        if(CheckGrounded()) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            if(jumpSound) {
                currentSoundSource.PlayOneShot(jumpSound, 1);
            }
        }
    }

    private void Move(float direction){
        if (direction != 0) {
            rb.velocity = new Vector2(direction * walkSpeed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        }
    }

    private bool CheckGrounded() {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, checkTheseLayers);
    }

    void FixedUpdate() {
        float movementInput = marioControls.Player.Move.ReadValue<float>();
        Move(movementInput);

        if (transform.position.y < -8) {
            Debug.Log("GAME OVER");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Coin") {
            if(coinSound) {
                currentSoundSource.PlayOneShot(coinSound, 1);
            }
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Enemy") {
            if(enemySound){
                currentSoundSource.PlayOneShot(enemySound, 1);
            }
            Destroy(other.gameObject);
        }
    }


    // this is needed for the controller class
    void OnEnable() {
        marioControls.Enable();
    }

    void Disable() {
        marioControls.Disable();
    }

    void OnDestroy(){
        marioControls.Disable();
    }
}
