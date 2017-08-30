## Spritesheets

This tutorial will show how to use the "Link" Spritesheet from the Assets folder.

### Creating separate sprites

- Click the spritesheet image in the editor, set the texture type to 'sprite'
- Set the sprite mode to 'multiple' and click the sprite editor button
- Click the 'slice' button
- Choose the 'grid by cell count' option. Count the number of rows and columns in the image and fill them in.
- Click 'slice'. Check that each link is now a separate sprite, and that all sprites are the same size.
- Click 'apply' and close the window.

### Creating a sprite animation manually
We will create a sprite animation step by step, so that we know exactly what is happening in the editor. 
This will also show you other options to animate apart from the sprite.

- Drag one sprite image (Link facing right) to the stage.
- Click **Window > Animation**, and then click 'create'
- Name your animation 'moveright' and save it in a separate folder called 'Animations'
- Click 'add property' - this is the property that will be animated. Click the 'plus' next to **sprite renderer > sprite**
- Note that you can animate lots of other stuff too!
- Drag the 10 images of 'Link walking right' into the timeline
- Set the framerate to 12 (60 frames per second is too fast for this spritesheet animation)
- Make sure the timeline has 10 frames. Sometimes Unity places an extra frame after the 1 minute mark. Delete that frame.
- Press play

### Controlling Link
Attach the "MoveLink" script to link, and run the game. You can control link with the arrow keys. Note that the animation always shows link moving right.

### Create the other three animations
You can use this shortcut to create the other three animations: Link walking left, Link walking down, Link walking up.
- Click the desired frames in the Assets pane by holding shift and clicking the first and last image.
- Drag them to the stage.
- Unity creates an animation clip for you with the right settings. Save it in the animations folder.
- Click play to view all four animations.
- Now you can remove all animations from the stage except Link moving right.
- Also delete all **animation controllers** except the one for Link moving right.

### Animation controller basics
You may have noticed Unity created an animation controller for each animation. The controller decides when to show an animation and can also transition between animations. We only need one controller.

We are going to make a basic example where Link shows the correct animation for moving left and right.

- Double click the controller for link moving right. This opens the **Animator**
- Run the game and note that the 'linkright' animation is running in the Animator
- Click inside the Animator space, choose 'create state > empty', name it 'linkleft'. 
- In the inspector, add the 'link left' **animation** to the **motion** field
- Now you have a controller with two animation states.
- Right-click the linkright state, choose 'add transition' and create a transition to linkleft.
- Do the same thing the other way around.
- You now have two states, connected to each other by a white arrow.
- Run the game. You will see the two animation states transitioning into each other!

### Removing the smooth transition
When switching from one animation to the next, Unity calculates 'in between' steps. This looks great in games where a 3D model can actually transition from one action to another. But this doesn't work for spritesheet animations. We just want our own 2D sprites to be drawn as they are.
- Click a white transition arrow between two states. 
- Open 'settings' in the inspector. Set Time, Duration and Offset to 0.
- Do this for the other transition arrow as well. Press play. 

### Set a condition for a transition
We want to show our animations only after a condition happens. If Link moves right, we show the 'moveright' animation.
- Set a transition property in the Animator. Click the 'plus' in the Animator Parameters window. Add a `float`
- Name the property `speed`
- Click the white transition arrow that points from 'moveleft' to 'moveright'
- Add a **condition** in the inspector. Also untick 'exit time'
- Set the condition to **speed greater than 0**
- Do the same thing for the transition from right to left, but set the condition to **speed smaller than 0**
- Run the game. We still only see one animation. That is because the **speed** property is not updated.

### Update Animator properties
We want to update the speed property when Link changes direction. We can do this from the 'MoveLink' script. First we get a reference to the Animator, and then we can change the speed property!
```
Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

Animator anim = GetComponent<Animator>();
anim.SetFloat("speed", direction.x);
```
Press play. If all went well, Link shows a different animation when moving left or right!

### Animation controller advanced
If we want Link to move in four directions, we could add two more states, and add transition arrows between all of them. From the 'right' state, you could build a transition to 'left', 'up' and 'down', and repeat that for every state. 

That would result in a spider-web of arrows. You can prevent that by using a **2D blend tree**

