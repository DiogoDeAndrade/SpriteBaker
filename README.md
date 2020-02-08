# SpriteBaker

This is an utility to convert something rendered by Unity to a frame animation

## Usage

* Setup the scene, making sure that your target animator starts playing the animation you're interested right away
* Add the SpriteBaker component to the camera you want to record
* Adjust the parameters:
  * Res: resolution of each of the frames in the output sprite sheet
  * Frame Count: How many frames of the animation you want to record
  * Snaps Per Frame: How many snaps you want of the animation currently active (for example, if you want to capture some frames of a particle system, like in the sample scene)
  * Time Between Snaps: How long between snapshots (again, it's useful if you want to capture some frames of a particle system)
  * Base name: Name of the file to output
  * Animator: Reference to the target animator that we want to control from the sprite baker. If none is given, the sprite baker will not control the animation
* Press play. When all the frames have been snapped, an image will appear in the Output directory at the base of your project, and the editor will leave Play mode.

## Tech stuff

* Basically this just renders to a texture, changing the animator state to make sure we capture what we want.
* This texture will have one frame of the animation per line, and each line will have all the snaps taken for that frame.

## Credits

* Code  by Diogo de Andrade
* Example space ship: [Modular Spaceships] by [Ebal Studios]

## Licenses

All code in this repo is made available through the [GPLv3] license.
The text and all the other files are made available through the 
[CC BY-NC-SA 4.0] license.
LPC art made available through the [GPLv3] and [CC-BY-SA 3.0.] licenses.

## Metadata

* Autor: [Diogo Andrade][]

[Diogo Andrade]:https://github.com/DiogoDeAndrade
[GPLv3]:https://www.gnu.org/licenses/gpl-3.0.en.html
[CC-BY-SA 3.0.]:http://creativecommons.org/licenses/by-sa/3.0/
[CC BY-NC-SA 4.0]:https://creativecommons.org/licenses/by-nc-sa/4.0/
[Ebal Studios]:https://assetstore.unity.com/publishers/24304
[Modular Spaceships]:https://assetstore.unity.com/packages/3d/vehicles/space/star-sparrow-modular-spaceship-73167
