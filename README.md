# Unity Introduction

Asset files for Unity Introduction lesson - Game Design and Development

## How to use

- [Download Unity](https://unity3d.com/get-unity/download) 
- Create a new project in Unity. Choose 2D
- Download the zip file from this repository. Place the Assets folder in your game project, overwriting the old Assets folder.

## Your first 2D game

#### Creating sprites from images
- Drag some of your own images into the Assets/Textures folder in Unity
- Click the little arrow on Asteroid image. Click sprite mode: multiple, and then open the sprite editor.
- Make a sprite for each asteroid.

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

#### Adding components to sprites
- Click on a sprite
- Note that it has a `transform` component and a `sprite renderer` component.
- Note the units in `transform` : 100 pixels equals 1 unity unit. The center of the world is 0,0,0
- Click 'Add Component' to see the whole list of available components. 

#### Adding code and running our first game
- Add the **Move script** component to the Asteroid sprite
- Click the 'play' button

#### Creating prefabs
- Drag the Asteroid that has the move script into the prefab folder
- Now drag three asteroids ships back from the prefab folder onto the stage

#### Adding public properties to scripts
- Open the **Move script** in the code editor
- Change the **private** variable into a **public** variable
- Go back to Unity, and give all asteroids a different speed. Click play.

#### Adding enemies
- Add a new script to the enemy sprite on the stage
- Copy the code from the move script (from the asteroid) into the new script
- Comment out the `update` code and enable the `start` code
- Save it as `enemy.cs`
- Add the `player script` to the player sprite

#### Adding 2D physics
For the player and enemies, we are going to need physics for accurate collision detection. 
- Add a **RigidBody 2D** and a **BoxCollider 2D** to the enemy and player sprites
- Run the game. What's happening?
- Set the gravity to 0 in project settings
- Create a prefab for the enemy in the same way as for asteroids
- Add multiple enemies to the scene with different speeds

#### Collisions
- Open the **Player script** in the code editor and remove the comments in one of the two lines. 
- Play the game and check what happens when the player collides with something.

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
