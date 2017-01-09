# BreakThoseBricks
Breaking bricks game for Unity3D

Simple Brick breaking game for Unity 3D. One main level complete with 3 other replica levels. This can be used as the base to create other brick breaking games.

# Errata

"Page 16 - Figure 3-10 shows the Paddle Game Object assigned to the Ball
Script correctly. However I do not mention that the user must drag and
drop the paddle_03 Game Object from the Hierachy View to the Paddle
variable of the Ball Script in the Inspector View of the Ball Game Object.
"

Page 30 (correction) - Figure 2-9 needs to be modified to show the
background with a pixels per unit of 50

Page 32 (missing sentence) "In Figure 2-3 under the Camera Inspector is
where the new size
can be set." to "In Figure 2-3 under the Camera Inspector is where the new
size
can be set. We will also need to modify the Tranform for Camera to X=8,
Y=6.1, Z=-10"

Page 35 (correction) - Readers should create the Brick empty object first
and then drag and drop greenbricks (Prefabs) into it. This will allow the
coordinates to be relative to the brick object instead of the screen.
