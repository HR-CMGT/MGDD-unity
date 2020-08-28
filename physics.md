# 2D Physics

This page aims to explain the different kinds of interaction between objects that have (or don't have) colliders and rigidbodies. In short:

- Use *colliders* if you want to detect collisions between objects.
- Use *rigidbodies* if you need Physics effects (gravity, friction, mass, velocity, bounce, etc.)

In most physics games, you'll use both on a gameObject. *If an object in a physics world does not need to move (a platform) you don't need a rigidbody, a collider is enough*.

## Moving objects

- Gameobject
- Gameobject with collider
- Gameobject with rigidbody
- Kinematic rigidbody

## Gameobject
- Move by setting position manually
```
transform.position = new Vector3(3,3,0);
```
- Use transform.Translate to move relative to the current position
- Use Vector3.up, Vector3.left, etc. as shortcuts for a `new Vector3()` in that direction
- Multiply by Time.deltaTime to prevent choppy movement caused by uneven calls to Update
```
void Update(){
  float speed = 3f;
  transform.Translate(Vector3.left * speed * Time.deltaTime);
}
```

## Collider

- Use if you need to detect collisions between gameobjects, but you don't need physics.
- Also causes physics reactions in Rigidbodies with Colliders.
- Can be detected by `rayCast` and `boxCast` - for precise collision detection in non-physics games.

## RigidBody

- Has velocity, responds to forces and gravity
- Move by setting a *start velocity*, and then by *applying force* during updates.
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
You should use colliders with rigidbodies for most physics objects.

## Kinematic RigidBody

- A kinematic rigidbody is part of the physics world, but needs full manual control (a player character). 
- Kinematic rigidbody has no velocity, does not respond to forces and gravity
- You could move the object with `transform.Translate`, like a non-physics gameobject
- BUT if you need to check collisions during movement you should use `movePosition`
```
void FixedUpdate(){
  rigidBody.movePosition();
}
```
