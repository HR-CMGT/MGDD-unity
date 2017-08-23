# Unity Introduction

Asset files for Unity Introduction lesson - Game Design and Development

## How to use

- [Download Unity](https://unity3d.com/get-unity/download) 
- Create a new project in Unity. Choose 2D
- Download the zip file from this repository. Place the Assets folder in your game project, overwriting the old Assets folder.

## Your first 2D game

#### Adding your own graphics
- Drag some of your own textures into the textures folder in Unity

#### Creating empty gameobjects
- Click on the **scene panel** and create two empty gameobjects: background and foreground
- Give the background a Z position of 10

#### Creating 2D sprites
You can create 2D easily by dragging images onto the stage or into the scene panel.
- Drag the space image on to the background gameobject in the scene panel.
- Drag one spaceship, one asteroid and one enemy onto the foreground gameobject in the scene panel.
- You can create multiple sprites from one image by using the sprite editor - this is called a spritesheet.

#### Adjust the camera to the size of the background
- Set the camera size to 3. This is the height of the background image / 100.

#### Adding components to sprites
- Click on the enemy ship sprite
- Click add component, add a **RigidBody2D** component
- Add a **BoxCollider2D** component
- Run the game. What's happening ?!?
- Set the gravity to 0 in project settings

#### Adding code
- Add a **Move script** component to the enemy

#### Creating prefabs
- Drag the enemy ship into the prefab folder
- Now drag three enemy ships back from the prefab folder onto the stage

#### Adding public properties to scripts
- Open the **Move script** in the code editor
- Change the **private** variable into a **public** variable
- Go back to Unity, and give all four enemy ships a different speed

#### More game objects!
- Create a prefab for the asteroid in exactly the same way as for the enemy ship
- You can even use the **Move script** for the asteroid
- Create the player ship, add the rigidbody2d and the boxcollider2d
- Experiment with the shape of the boxcollider2d
- Add the **Player script** to the player and run the game

#### Collisions
- Open the **Player script** in the code editor and remove the comments in one of the two lines. Check what happens when the player collides with something.
- Can you make the asteroids collide with the enemies?

#### Multiplayer
- The player script responds to key presses. Make these keys public variables.
- Now add two player ships to the game. Give each ship their own keyboard controls.
- Add a collision layer, so that players can't collide with each other

#### Score
- Check the Update function in the player code. Place a log message there: `Debug.Log('flying around')`
- Let's add a score counter : the player gets points for staying alive by avoiding enemies and asteroids
- Now log the score before the player is destroyed.
- Finally, we want to display the score on screen instead of in the debug window.

#### Levels
- Duplicate the scene. 
- In the new scene, place more enemies and asteroids. You have levels now!

#### Finishing the game
- Open the [code snippets page](./snippets.md)
- If an enemy leaves the screen on the left side, place it back on the right side
- Switch to the new level once your score is 1000
- Make the space background scroll

### Bonus
Adding gameobjects while the game is running. Copy the example code.
- Add an explosion when there is a collision
- Add a bullet when the player presses space

