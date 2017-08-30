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

### Create the other three animations
You can use this shortcut to create the other three animations: Link walking left, Link walking down, Link walking up.
- Click the desired frames in the Assets pane by holding shift and clicking the first and last image.
- Drag them to the stage.
- Unity creates an animation clip for you with the right settings. Save it in the animations folder.
- Click play to view all four animations.
- Now you can remove all animations from the stage except Link moving right.
- Also delete all **animation controllers** except the one for Link moving right.

### Controlling Link
Attach the "MoveLink" script to link, and run the game. You can control link with the arrow keys. Note that the animation always shows link moving right.

### The animation controller
You may have noticed Unity created an animation controller for each animation. The controller decides when to show an animation and can also transition between animations.
- Open the controller for link moving right
- Click 'create state > empty', name it 'link left'.
- In the inspector, click the little circle next to 'motion' and add the 'link left' animation there!
- Now you have a controller with two animations.

