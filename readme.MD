Gui scroll text

Customable to display as many lines of text as needed. You set the lines of text by clicking guiManager og type in the text you want
into the inspector.

Things to do to use these scripts:<br>
 - Add a UI Canvas to the scene.<br>
 - Add a empty game object to the scene.<br>

Drag the GuiManager script into the empty game object. You will then have some settings in the inspector.<br>
![GuiManager Settings](https://soltveit.org/files/gui-manager1.jpg)

The Ui Text should containt the GuiText prefab.<br>
Wait time is the time (in seconds) between each scroll line is spawned. If you have long lines, you might need to increase the timer.<br>
Y position is where on the Y-axis to spawn the scroll text. By default there is no need to set the x-axis as it spawn outside the screen
on the right side.<br>

Size is how many lines of text you want.<br>
Element0 to xx is the lines of text to spawn.<br>

This little project consist of two script files.<br>
GuiMover.cs - Moves the text and destroy the text once it leaves the screen on the left side.<br>
GuiManager.cs - Spawns the text into the screen (canvas).<br>

GuiMover.cs<br>
-----------<br>
When this script starts, it find it RectTransform component, the Canvas and make the Canvas the parrent of the UI Text.<br>
In the update method we move the text to the left with the speed specified in the speed variable.<br>
The LateUpdate method check if the bottom right corner of the RectTransform of the Text, has left the screen. If it has, destroy the object.<br>

GuiManager.cs<br>
-------------<br>
An IEnumerator has to be made instead of a method, since we want to pause the for-loop to get a delay between the lines of text.<br>


The IEnumerator MyCoroutine() cycle thru all of the lines of text, spawns the text, wait for x amount of seconds. At the bottom of the
for-loop you will see this code:
´´´
if (x == textMessages.Length - 1)
    x = -1;
´´´
This loops the text by reseting the x once the last line of text is read.<br>