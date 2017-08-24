## Code Snippets for Lesson 1
Feel free to experiment! You could start by adding this empty script to a gameobject, and then add some of the examples.
```
using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {

	// this is where you put variables
	public float score = 1f;

	// every object has a start and update function
	void Start() {
	     Debug.Log("My score is " + score);
	}

	void Update() {
             Debug.Log("I am updating!");
	}
}
```

#### Remove gameObject after it leaves the screen
```
void OnBecameInvisible() {
    Destroy (gameObject);
}
```

#### Click the object
The object needs to have a Collider2D to register mouse clicks.
```
void OnMouseDown(){
	Debug.Log("you clicked me!");
}
```

#### World and camera space
Gameobjects live in a `world space`. The center of this world is 0,0 and the world reaches out in all directions infinitely.

The camera watches a small part of this world. The camera coordinates are **0,0 (left, top)** to **1,1 (bottom, right)**. This is really useful if we work with different sizes of screens because we don't need to know precisely what the size of the screen is. 

If we want to know if a gameobject is still within the camera view, we have to compare those two coordinate systems.

**Check if a gameobject is within camera view**
We translate the gameobject position in the world to the camera position
```
void Update() {
	Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
	if(pos.x < 0.0) {
		Debug.Log("I am left of the camera's view.");	
	}
	if(pos.x > 1.0) {
		Debug.Log("I am right of the camera's view.");	
	}
}
```
**Place a gameobject to the right of the camera view**
We translate the camera position to a world position, so we can place the object there
```
void Start() {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1,0));
}
```

#### Switching scenes

Create a new scene named 'gameover'. We'll switch to the gameover scene after a collision.

```
using UnityEngine.SceneManagement;
void OnCollisionEnter2D(Collision2D coll) {
    SceneManager.LoadScene("gameover");
}
```
#### Pressing CTRL button
```
void Update() {
	if (Input.GetButtonDown("Fire1")) {
	    Debug.Log("Fire a bullet!");
	}
}
```
#### Fire a bullet
Add this code to the player ship. We'll use a public variable for the gameobject (a bullet) that is going to be added. In the editor, drag the bullet prefab into the variable field.
```
public Transform bullet;
void FireRocket () {
	Vector3 offset = new Vector3(0.6f, 0);
	Transform mybullet = (Transform) Instantiate(bullet, transform.position + offset , transform.rotation);

	// this code puts the gameobject under the same parent gameobject (foreground or background)
	mybullet.transform.parent = transform.parent;
}
```

#### Automatically repeating a function
You could use this to keep adding asteroids to the game. The asteroids should also remove themselves when they exit the screen.
```
public Transform asteroid;
void Start() {
    InvokeRepeating("SpawnAsteroid", 1F, 0.8F);
}
void SpawnAsteroid() {
    Instantiate(asteroid, new Vector3(4.3f,Random.value * 6-3, 0), Quaternion.identity) as GameObject;
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

#### A global script
Create an empty gameobject in the scene panel and name it `scripts`. Attach this global script component. This code will run regardless of what is happening on screen. You can use it to keep track of player progress or keep a highscore. If you add the line `asdf` the script will not be deleted even when you leave the scene. 
```

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
