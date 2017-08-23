## Code Snippets for Lesson 1

**Remove gameObject when it leaves the screen**
```
void OnBecameInvisible() {
    Destroy (gameObject);
}
```

### How to make a scrolling background

**code**

```
public class ScrollBackground : MonoBehaviour {

	public float speed = 0.5f;
	
	void Update () {
		Vector2 offset = new Vector2(Time.time * speed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
```

**gameobject**

- in assets folder click the image, make it a TEXTURE (not a sprite)
- click **wrap mode repeat**
- create a **3d quad** object in the game, instead of a gameObject
- make the quad the same size as the screen (game 800x600 pixels, quad scale is 8 x 6)
- drag the texture on it
- add a directional light to the scene

[Watch the tutorial](https://www.youtube.com/watch?v=HrDxnMI7pCc)
