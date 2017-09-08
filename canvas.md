## User Interface

# UI elements and Canvas

Unity supports a responsive canvas that resizes itself along with the size of the actual screen that the game is displayed on.
This is fundamental for UI elements. You probably want your buttons and menus to align nicely along the borders or corners of the screen,
regardless of resolution.

### Setting the canvas

- Add a new gameobject and choose `UI > Canvas`, or choose any other UI element, which will automatically add a canvas.
- Click the canvas and note the view settings in the inspector is `Screen space - Overlay` - this will display your canvas in a HUGE size.
You'll need to zoom out pretty far to see the whole canvas.
- Click the `game` tab to see how the canvas will render in-game.
- If you want your canvas to always display in the size of your 2D game you can set view to `Screen space - Camera`
- Set your game's main camera as the canvas camera
- Under `Canvas scaler script` you'll want to set UI Scale Mode to `Scale with screen size`
- Set `reference resolution` at the size at which you design your UI (and game). For now, keep it at 800 x 600.
- For a portrait (horizontal) game it's best to drag the **match** slider to **height**. This will cause Unity to always interpret the height of
your game as 600 pixels, and only adjust the width according to the size of the screen. This will make it easier to predict the behavior of the different anchor points.

### Anchor points

- Add a UI Image : `UI > UI Image`
- Click the image, note that it has a `Rect Transform`
- Click the anchor icon in Rect Transform, and select the bottom right anchor
- Note that the anchor position is shown on the canvas gameobject.
- Now you can position the Image in the scene to where you want.
- Note that the position of the image is **relative** to the **anchor**
- Test this by clicking the game tab and setting its size to `free aspect ratio`
- Drag the window borders. The UI Image should always remain at the bottom right of the game!

### Scaling

- Click the UI Image, click the Anchors button.
- Choose `stretch` and resize the image to 80% of the game screen, with a distance of 10% from every border.
- Resize the game in the game tab, and note that the image will always be 80% of the screen, regardless of the size.

### Sorting

Note that inside the canvas gameobject, you can sort the depth by dragging items in the right order, right in the scene panel. 
You don't need sorting layers or Z depth.

### 9-slice-scaling

When resizing an image (either by using the canvas, or by dragging the resizing handles manually), your image may become distorted.
To prevent this, we can use 9-slice-scaling.

- Import the `button.png` image from the Assets folder in this repository.
- Set the image as the background for a UI Button or UI Image
- If you resize this image, the rounded corners will become distorted, and the borders size will be different horizontally and vertically.
- We will add 9 slices to the image by clicking the texture. Keep the **Sprite Mode** at **Single** and click the sprite editor.
- Drag the green borders from the sides towards the center of the image. Create 9 areas this way. Click Apply.
- Now click the UI element again, set **image type** to **sliced**
- If you resize the image, the borders should stay the same regardless of size!

### Autosizing buttons

We can use Unity's layout system to make sure a button is always just large enough to display its own text. This is handy when the text changes in-game, for
example due to localisation.

- Create a UI Button with a 9-sliced image.
- Click `Add component > Layout > Content Size Fitter`
- Set Horizontal to **preferred size** and keep Vertical at **unconstrained**
- Now click `Add component > Layout > Horizontal Layout Group`
- Check both `Child controls size` boxes.
- Now select the button label and start typing. The button should automatically grow along with the label text!
- You can adjust the padding to keep some empty space around the text

### Links
- [Tutorial resizing image](https://www.youtube.com/watch?v=2VrtXiUnJH0)
