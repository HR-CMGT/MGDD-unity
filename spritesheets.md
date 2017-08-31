# Spritesheet Animation

This tutorial will show how to animate the sprites from the "Link" Spritesheet in the Assets folder.

## Creating sprites from a spritesheet

- Click the spritesheet image in the editor, set the texture type to 'sprite'
- Set the sprite mode to 'multiple' and click the sprite editor button
- Click the 'slice' button
- Choose the 'grid by cell count' option. Count the number of rows and columns in the image and fill them in.
- Click 'slice'. Check that each link is now a separate sprite, and that all sprites are the same size.
- Click 'apply' and close the window.

## Create Link and add movement
- Create a new empty gameobject
- Drag **one** of the Link images from the spritesheet onto the object
- Add the 'MoveLink' script to the gameobject
- Press play and walk around the screen.

## Animation basics
- A gameobject can have an **animator** component
- The animator component needs an **animation controller** 
- And the animation controller has **animation clips**

#### Animation controller
- The controller can have several animation clips
- The controller can switch between animation clips

#### Animation clips
- An animation clip changes the properties of the gameobject, for example: position, sprite image, color

#### Shortcut
You can create a gameobject with an animator, a controller and a movieclip just by dragging a bunch of sprites onto the stage!
- Select all the sprites of 'link moving right' in your assets folder, drag them onto the stage, and press play.

The shortcut is handy for single animations, but we want to add more than one animation to Link, and we want to understand what is actually happening (right?)
- Undo and delete until we are at the starting point again - you should have a gameobject with a transform and a sprite renderer with only one sprite.
- We are going to create all separate components manually and 'link' them all together.

## Adding the animator, controller and clip
- Right click in the Assets window, create an **Animation controller** and name it 'linkcontroller'
- Also add an **Animation clip** and name it 'moveright'
- Select the Link gameobject on the stage (this gameobject should only have a sprite renderer with one sprite image)
- Click 'add component', add a **Animator**
- In the inspector, add the **linkcontroller** to Link's **animator component**

### Adding clips
Now that Link has an animation controller, we can add animation clips
- Doubleclick the animation controller in the assets window. This opens a new **animator window**
- In this window we can add animations. These are called **states**
- Right click the window and add a new empty state. Name the state 'rightstate'
- In the inspector, click 'motion' and select the 'moveright' animation clip that you already made
- The state should turn orange and have an arrow pointing from 'entry' to 'rightstate'
- There's still nothing to see when you press play, but finally we can create an actual animation!

### Creating the actual animation
- Select Link on the stage
- Open the **animation window**
- Under the small red 'record' button you should find the name of your animation clip 
- If you don't, then the clip is not added to link's controller, or the controller is not added to link's animator component
- If you do, you can click 'add property' 
- This is the property that will be animated. Click the 'plus' next to **sprite renderer > sprite**
- Note that you can animate lots of other stuff too!
- Drag the 10 images of 'Link walking right' into the timeline
- Set the framerate to 12 (60 frames per second is too fast for this spritesheet animation)
- Make sure the timeline has 10 frames. Sometimes Unity places an extra frame after the 1 minute mark. Delete that frame.
- Press play - you should see link animating! Congratulations!

## Create the other three animations
Create three more clips (link moving left, up and down) by using the shortcut:
- Click the desired frames in the Assets pane by holding shift and clicking the first and last image.
- Drag them to the stage.
- Unity creates an animation clip for you with the right settings. Save it in the animations folder.
- Click play to view all four animations.
- Now you can remove the three new animations from the stage
- If Unity created three more animation controllers, you can delete them too

## Adding more animations to the controller
The controller decides when to show which animation. It can also transition between animations. We are going to learn how to alternate between two animation clips.
- Open Link's controller in the **Animator**
- Click inside the Animator space, choose 'create state > empty', name it 'leftstate'. 
- In the inspector, add the 'link left' **animation** to the **motion** field
- Now you have a controller with two animation states! But the 'leftstate' never plays.
- Right-click the 'rightstate', choose 'add transition' and create a transition to leftstate.
- Do the same thing the other way around.
- You now have two alternating states, press play to see the effect!

### Removing the smooth transition
When switching from one animation to the next, Unity calculates 'in between' steps. This doesn't look very good when using spritesheets.
- Click the white transition arrows and set Time, Duration and Offset to 0.

## Set a condition for an animation
We want to show our animations only after a condition happens. If the player presses right, we want to show the 'moveright' animation. To do this, we will add a variable to the animator, and update that variable from our 'MoveLink' script.
- Click the 'plus' in the Animator Parameters window, add a `float` property and name it 'speed'
- Click the white transition arrow that points from 'moveleft' to 'moveright'
- Add a **condition** in the inspector. 
- Set the condition to **speed greater than 0**
- While you're here, you can also untick 'exit time'. This means that the animation won't finish playing before a transition.
- Do the same thing for the transition from right to left, but set the condition to **speed smaller than 0**
- Almost finished, but we still need to update 'speed' when the player presses a button!

### Update properties
When the 'MoveLink' script reads the player input, we will pass the horizontal input value to the the speed property. 
```
Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
GetComponent<Animator>().SetFloat("speed", direction.x);
```
Press play. If all went well, Link shows a different animation when moving left or right!

### Animation controller advanced
Once you have more than a few states, the transition arrows tend to become a spider web. To keep your project maintainable, you can use a **2D blend tree**. 

- Remove everything from the **Animator**
- Change the property 'speed' to 'xspeed'. Add a float property 'yspeed'
- Click **create state > from new blend tree**
- Double click the new state and set the type to **2D Simple Directional**
- Make sure the blend tree shows the xspeed and yspeed properties
- Click **motion > add motion field**
- In the new field, click the circle next to 'Motion (None)' and select the 'Link Up' animation.
- For 'Link Up' set X to 0 and Y to 1
- Save and play, to see if the animation is playing
- Now add three more motion fields for Link Down, Link Left, and Link Right, and set their X, Y values accordingly.
- Finally, we need to set the xspeed and yspeed properties from the code of our MoveLink script
```
Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
GetComponent<Animator>().SetFloat("xspeed", direction.x);
GetComponent<Animator>().SetFloat("yspeed", direction.y);
```
- Save the project and press play!

### Idle state
We should now have a Link that can run in four directions and display four animations. Let's add an Idle state where Link does nothing.
- Select Link on the stage.
- Open the **Animation** window (not the Animator) and open the drop-down menu under the small red record button
- Click 'Create new clip', save it as 'idle'
- Drag one sprite of Link facing right into one frame. Save the animation.
- Now go back to the **Animator** window
- If the idle animation has been added here automatically, you can delete it
- Double click the blend tree, and add a motion field.
- Select the idle animation and leave X,Y at 0
- Save the project and press play!

## Set animations by code
We have learned how to use variables in the animator to decide what movieclip needs to be played at what condition. This allows game designers and artists to tweak their animations without using code. It also allows you to add states and animations without the coder having to update anything.

We are going to look at the option of setting animation state directly through code, without using a blend tree or transitions. This works quite well for 2D spritesheets, since we don't need any transitions.

- Double click the controller in the assets panel to open the animator window, and remove everything
- Add an empty state, name it 'rightstate'. Add the 'moveright' animation to the state.
- Create left, up and down states with animations, but don't add any transition arrows.
- Test playing the 'left' animation with the following code:
```
void Start(){
		GetComponent<Animator>().Play("leftstate");
}
```
- To update the state when the direction changes, we need to keep track of what animation is currently playing. Then, we can update it only when the direction changes. In this code, we have also made the 'state' names public, so we can still change the states through the Unity editor:
```
using UnityEngine;
using System.Collections;

public class MoveLink : MonoBehaviour {

	public float moveSpeed = 3f;
	public string leftstate = "leftstate";
	public string rightstate = "rightstate";
	private string currentstate = "rightstate";

	void Update() {
		// move link
		Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

    // check what the current direction is
		string newstate = (dir.x < 0) ? "leftstate" : "rightstate";

    // only change the state when the direction has changed
		if(newstate != currentstate){
			currentstate = newstate;
			GetComponent<Animator>().Play(currentstate);
		}
	}
}

```
