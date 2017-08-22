# Unity Introduction

Files for Unity Introduction lesson - Game Design and Development

## How to use

- [Download Unity](https://unity3d.com/get-unity/download) 
- Create a new project in Unity. Choose 2D
- Download the zip file from this repository and place the files from the zip in your project folder

#### Adding your own graphics
- Drag some of your own textures into the textures folder in Unity

#### Creating empty gameobjects
- Click on the **scene panel** and create two empty gameobjects: background and foreground
- Give the background a Z position of 10

#### Creating sprites
You can create 2D sprites easily by dragging images onto the stage or into the scene panel.
- Drag the space image on to the background gameobject in the scene panel.
- Drag one spaceship, one asteroid and one enemy onto the foreground gameobject in the scene panel.

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
- Open the **Player script** in the code editor and edit the collision function
