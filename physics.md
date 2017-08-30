# 2D Physics

This page aims to explain the different kinds of interaction between objects that have (or don't have) colliders and rigidbodies.

- Gameobject
- Gameobject with collider
- Gameobject with rigidbody
- Gameobject with kinematic rigidbody
- Gameobject with (kinematic) rigidbody and collider

## Gameobject
- Move by setting position manually
```
transform.position = new Vector3(3,3,0);
```
- Use transform.Translate to move relative to the current position
- Multiply by Time.deltaTime to prevent choppy movement caused by uneven calls to Update
```
void Update(){
  float xpeed = Time.deltaTime * 4;
  transform.Translate(xspeed, 0, 0);
}
```

## Gameobject with Collider
- Does not respond to the physics simulation (gravity, friction)
- Causes physics reactions in Rigidbodies with Colliders
- Causes `onCollision` and `onTrigger` events in Rigidbodies with Colliders
- Can be detected by `rayCast` and `boxCast` - for precise collision detection in non-physics games.

## Gameobject with RigidBody
- Has velocity, responds to forces and gravity
- Move by setting a start velocity, and by applying force during updates
- Use `FixedUpdate` without Time.deltaTime
```
void Start(){
  rigidBody.velocity = new Vector3(3,3,0);
}
void FixedUpdate(){
  Vector2 force = new Vector2(2, 2);
  rigidBody.AddForce(force, ForceMode2D.Impulse);
}
```

## Gameobject with Kinematic RigidBody
A kinematic rigidbody is part of the physics world, but needs full manual control (a player character). 
- Kinematic rigidbody has no velocity
- Does not respond to forces and gravity
- You could move the object with `transform.Translate`, like a non-physics gameobject
- If you want to check collisions during movement you can use `movePosition`
```
void FixedUpdate(){
  rigidBody.movePosition();
}
```

## Gameobject with (Kinematic) RigidBody and Collider
- Responds to physics interactions (bounce off other Colliders)
- Causes and responds to `onCollision` and `onTrigger` events
