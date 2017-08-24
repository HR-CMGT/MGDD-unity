## Code Snippets for Lesson 1

#### Remove gameObject after it leaves the screen
```
void OnBecameInvisible() {
    Destroy (gameObject);
}
```

#### Reset gameobject position after it leaves the screen

#### Switching scenes

Create a new scene named 'gameover'.

```
using UnityEngine.SceneManagement;
void OnCollisionEnter2D(Collision2D coll) {
    SceneManager.LoadScene("gameover");
}
```

#### Movement with physics

If the gameobject has a rigidbody2D, you can set the initial velocity in the start method. In our space game, there is no gravity or friction, so the object will keep the same velocity:
```
public Vector2 speed = new Vector2(-1, 0);
void Start() {
    GetComponent<Rigidbody2D>().velocity = new Vector2(speed.x,speed.y);
}
```
If you need to change the speed during gameplay, you can set the velocity or add force in FixedUpdate
```
void FixedUpdate()
{
    // set velocity
    Vector2 movement = new Vector2(2, 2);
    GetComponent<Rigidbody2D>().velocity = movement;
    
    // or add force
    Vector2 force = new Vector2(2, 2);
    GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
}

```

#### Movement without physics

Set the X,Y position of an object. The third parameter Z is not used.
```
transform.position = new Vector3(4, 4, 0);
```
Use `translate` to animate objects that don't have a rigidbody2D.
```
float distancePerSecond = 1;
void Update() {
   transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
}
```

#### Rotate in direction of another gameobject
```
transform.right = targetobject.position - transform.position;
```




#### Store rigidbody in a variable
```
private Rigidbody2D rb;

void Start() {
    rb = GetComponent<Rigidbody2D>();
}
```

#### Pause game
```
void Pause() {
   Time.timeScale = 0;
}
    
void Resume() {
   Time.timeScale = 1;
}
```

#### Scrolling background

The following script checks the start position of an image, and scrolls it to the left for its own width in pixels. Then places itself back at its start position.

Attach the script to a 2D sprite that has a background image. Duplicate the whole 2D sprite and place both backgrounds next to each other. Make scrollSpeed public so you can tweak it in the editor.
```
public class ScrollImage : MonoBehaviour {
        private float scrollSpeed = 2;
	private float startPosition;
	private float tileSize;

	void Start (){
		startPosition = transform.localPosition.x;
		tileSize = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	void Update (){
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
		transform.localPosition = new Vector3(startPosition - newPosition, 0);
	}
}
```

#### Use 3D texture wrap to create a scrolling background
This code uses a 3D feature to wrap an image around an object, creating a scrolling effect.
```
public class ScrollBackground : MonoBehaviour {
	public float speed = 0.5f;
	void Update () {
		Vector2 offset = new Vector2(Time.time * speed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
```

- in assets folder click the background image and make it a TEXTURE, not a sprite
- click **wrap mode repeat**
- create a **3D quad** object in the game, instead of a 2D gameObject
- make the quad the same size as the screen (if the game is 800 x 600 pixels, the quad scale is 8 x 6)
- drag the texture on the quad
- add a directional light to the scene (otherwise the texture will be invisible)

[Watch the tutorial](https://www.youtube.com/watch?v=HrDxnMI7pCc)
