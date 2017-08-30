## Unity Code Snippets
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
### Accessing components
A gameobject can access its own components with `GetComponent`:
```
Rigidbody2D body = GetComponent<Rigidbody2D>();
MoveScript move = GetComponent<MoveScript>();
```
You can store the reference in a variable for readabilty
```
private Rigidbody2D body;

void Start() {
    body = GetComponent<Rigidbody2D>();
}
void Update(){
    body.velocity = new Vector3(2,2);
}
```

### Remove gameObject after it leaves the screen
```
void OnBecameInvisible() {
    Destroy (gameObject);
}
```

### Click an object
The object needs to have a Collider2D to register mouse clicks.
```
void OnMouseDown(){
	Debug.Log("you clicked me!");
}
```

### Sorting layers
The scene hierarchy does not represent layers. To decide what objects are drawn above or below other objects, we can use the Z depth of their containers. A large Z value means the object is further away from the camera. Because our game is 2D, there is no visual effect for having a larger Z value.

You could also use `sorting layers` of a 2D sprite to decide which objects are drawn first. Click the **Sprite Renderer > Sorting Layer** and add a new layer. This screen allows you to decide the visual order of your objects.


### World and camera space
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

### Switching scenes

Create a new scene named 'gameover'. Open **File > Build Settings** and drag all your scenes from the Unity editor into 'scenes in build'. This script will transition to the new scene after a collision:
```
using UnityEngine.SceneManagement;
void OnCollisionEnter2D(Collision2D coll) {
    SceneManager.LoadScene("gameover");
}
```

### Player input
Fire1, Fire2, Fire3 are mapped to Control, Option (Alt), and Command, but you can also listen to any key directly.
```
if (Input.GetButtonDown("Fire1")) {
    Debug.Log("You pressed CTRL!");
}
if (Input.GetKeyDown("space")) {
    Debug.Log("You pressed Space!");
}
if (Input.GetKey (KeyCode.W) {
    Debug.Log("You pressed W!");
}
```
Horizontal and Vertical input respond to the W,A,S,D keys and the cursor keys. They return values from -1 to 1. You can change the default key bindings in **edit > project settings > input**. If you want to control two ships with different controls:
- In the input manager add input for player two by setting Axis to 20
- Rename the two new Axis from 'cancel' to 'PlayerTwoHorizontal' and 'PlayerTwoVertical'
- Remove "W A S D" from the default Axis and add them to your own Axis
- Add the following code to make the input a public variable
- In the Unity editor, change the input for player two.
```
public class Player : MonoBehaviour {
	public string xAxis = "Horizontal";
	public string yAxis = "Vertical";
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis(xAxis) * Speed, Input.GetAxis(yAxis);
	}
}
```

Mouse position
```
Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
```
Mouse acceleration
```
float mouseXspeed = Input.GetAxis("Mouse X");
float mouseYspeed = Input.GetAxis("Mouse Y");
Vector2 mouseSpeed = new Vector2(mouseXspeed, mouseYspeed);
```

### Fire a bullet
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

### Automatically repeating a function
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

### Movement with physics

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

### Movement without physics

Set the X,Y position of an object. The third parameter of Vector3 can be left out, since we work in 2D we can always leave it at 0.
```
transform.position = new Vector3(4, 4);
```
Use `translate` to animate objects that don't have a rigidbody2D.
```
float distancePerSecond = 1;
void Update() {
   transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
}
```

### Rotate and move in direction of another gameobject
You can use this code to make a guided missile, or to make an object follow the mouse
```
// face towards another gameobject
transform.right = targetobject.position - transform.position;

// move in the direction of facing
transform.Translate(Vector3.right * 0.02f);
```

### Pause game
```
void Pause() {
   Time.timeScale = 0;
}
    
void Resume() {
   Time.timeScale = 1;
}
```

### Requiring a component
Sometimes your script needs your gameobject to have a certain component, for example a RigidBody2D. To prevent errors, you can require the component from your script:
```
[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
}
```

### Accessing other gameobjects
Your script component can search for other gameobjects in the scene. If an enemy ship would want to find the player gameobject we could use:
```
GameObject player = GameObject.Find("ship");
Debug.Log("the player position is " + player.transform)
```
You can also find the script component of the player gameobject and then call a function
```
Shipscript pl = GameObject.Find("ship").GetComponent("Shipscript") as Shipscript;
pl.DoSomething();
```

If you add tags to your prefab components in the Unity editor, you can search for those objects too. Note that the search function returns an array. You can loop through the array with the `foreach` function.
```
GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
foreach(object e in enemies) {
	Debug.Log ("found enemy " + e);
}
```

### A global script
Create an empty gameobject in the scene panel and name it `scripts`. Attach this global script component. This code will run regardless of what is happening on screen. You can use it to keep track of player progress or keep a highscore. If you add  `DontDestroyOnLoad` the script will keep updating even when you leave the scene. 
```
using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    public int score = 0;
    void Awake(){
	DontDestroyOnLoad(this);
    }
    void AddScore(n:int){
	score += n;
    }
}
```
Your gameobjects can access the manager script by searching for it and then calling its functions:
```
Manager m = GameObject.Find("scripts").GetComponent("Manager") as Manager;
m.score = 10;
m.AddScore(10);
```

### How to make sure there is only one global script
If you use `DontDestroyOnLoad` your global script is not removed after switching scenes. If you switch back to the scene where the global script was created, you suddenly have two global scripts. There are two ways to prevent this:
- Create the global script in a scene that is only used once, for example the first splash screen.
- Make the global script a `Singleton`: a class that can only ever have one instance:
```
public class Manager : MonoBehaviour {

	public static Manager Instance;
	
	void Awake()
	{
		// check if we already have a manager
		if(Instance) {
			Debug.LogError("Since there is already a game manager so we will destroy ourselves!");
			Destroy(gameObject);
		} else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
			Debug.Log("Creating the first and only game manager");
		}
	}
}
```

### Scrolling background

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

### Use 3D texture wrap to create a scrolling background
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
