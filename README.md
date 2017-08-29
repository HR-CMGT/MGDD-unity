# Unity Introduction

Asset files for Unity Introduction lesson - Game Design and Development

## How to use

- [Download Unity](https://unity3d.com/get-unity/download) 
- Create a new project in Unity. Choose 2D
- Download the zip file from this repository. Place the Assets folder in your game project, overwriting the old Assets folder.

## Your first 2D game

#### Creating sprites from images
- Check the images in the Assets/Textures folder in Unity. 
- Feel free to drag your own space-related images in there.
- Check that the the texture type (in the inspector) of all images is set to `sprite`
- Click the little arrow on an image. This will show the default sprite for that image.
- To create multiple sprites from one image you can set **sprite mode: multiple**, and then open the sprite editor.
- In the sprite editor click **slice** to create multiple sprites from one image.

#### Creating empty gameobjects
- Click on the **scene panel** and create 3 empty gameobjects: background, middleground and foreground
- Give the background a Z position of 10, and the middleground a Z of 5. 
- Note that the camera has a negative Z position.

#### Creating 2D game sprites
You can create 2D sprites by dragging sprites from Assets/Textures onto the stage OR into the scene panel.
- Drag the space image on to the background gameobject in the scene panel.
- Drag one asteroid onto the middleground gameobject
- Drag one spaceship and one enemy onto the foreground gameobject in the scene panel.

#### Adjust the camera to the size of the background
- Set the camera size to 3. This is the height of the background image / 100.

#### Layers
The scene hierarchy does not represent layers. To decide what objects are drawn above or below other objects, we can use the Z depth of their containers. A large Z value means the object is further away from the camera. Because our game is 2D, there is no visual effect for having a larger Z value.

You could also use `sorting layers` of a 2D sprite to decide which objects are drawn first. Click the **Sprite Renderer > Sorting Layer** and add a new layer. This screen allows you to decide the visual order of your objects.

#### Adding components to sprites
- Click on a sprite
- Note that it has a `transform` component and a `sprite renderer` component.
- Note the units in `transform` : 100 pixels equals 1 unity unit. The center of the world is 0,0,0
- Click 'Add Component' to see the whole list of available components. 

#### Adding code and running our first game
- Add the **Move script** component to the Asteroid sprite
- Click the 'play' button

#### Creating prefabs
- Drag the Asteroid that has the move script from the scene panel into the prefab folder
- Now drag three asteroids ships back from the prefab folder onto the stage

#### Adding public properties to scripts
- Open the **Move script** in the code editor
- Change the **private** variable into a **public** variable
- Go back to Unity, and give all asteroids a different speed. Click play.

#### Adding enemies
- Add a new script to the enemy sprite on the stage
- Add the `EnemyMove` script to the enemy
- Add the `Player` script to the player

#### Adding 2D physics
For the player and enemies, we are going to need physics for accurate collision detection. 
- Add a **RigidBody 2D** and a **BoxCollider 2D** to the enemy and player sprites
- Run the game. What's happening?
- Set the gravity to 0 in **project settings > physics 2D**
- Create a prefab for the enemy in the same way as for asteroids
- Add multiple enemies to the scene with different speeds

#### Collisions
- Open the **Player script** in the code editor and remove the comments in one of the two lines. 
- Play the game and check what happens when the player collides with something.

#### Multiplayer
- Create a prefab from the player, and drag another player ship into the scene
- Run the game and press the controls. You'll see that both ships are controlled with the same keys.
- To give each ship its own controls, we are going to add an input axis.
- Go to **edit > project settings > input** and set the number of Axis to 20
- Rename the two new Axis from 'cancel' to 'PlayerTwoHorizontal' and 'PlayerTwoVertical'
- Remove "W A S D" from the default Axis and add them to your own Axis
- Edit the player script to make the input a public variable
- In the Unity editor, change the input for player two to 'PlayerTwoHorizontal' and 'PlayerTwoVertical'
```
public class Player : MonoBehaviour {
	public string xAxis = "Horizontal";
	public string yAxis = "Vertical";
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis(xAxis) * Speed, Input.GetAxis(yAxis);
	}
}
```

#### Prevent friendly collisions
We don't want the players to be destroyed if they hit each other. If we add bullets to the game, we don't want the player to be destroyed by their own bullets. We can use collision layers to achieve this.
- Click any gameobject. In the top right of the editor, click **Layer > add layer**
- Add a layer named `players`. 
- Click both player gameobjects. In the top right of the editor, click **Layer > players**
- Open **project settings > physics 2D** and untick the box for `players`
- If you add bullets to your game, you can also add them to the `players` layer.

#### Levels
- Duplicate the scene. 
- In the new scene, place more enemies and asteroids.
- Open **File > Build Settings** and drag all your scenes from the Unity editor into 'scenes in build'.
- You can transition to the scene with this code:
```
using UnityEngine.SceneManagement;
void OnCollisionEnter2D(Collision2D coll) {
    SceneManager.LoadScene("gameover");
}
```

### Finishing the game
Open the [code snippets page](./snippets.md) and try to add some or all of the following functionality:

- Add a particle system component to make smoke emit from the space ships
- If an enemy leaves the screen on the left side, place it back on the right side.
- If an enemy is destroyed, create a new one
- Switch to the new level once your score is 1000.
- Make the space background scroll.
- Keep adding asteroids to the right side of the screen, remove them when they leave the screen.
- Add a bullet when the player presses space.
- Let the bullet collide with enemies and asteroids.
