using Godot;
using System;

public class YeetedCat : KinematicBody2D
{
    private Vector2 _Velocity = new Vector2();

    [Export]
    private Vector2 _InitialVelocity = new Vector2();

    public override void _PhysicsProcess(float delta)
    {
        var rel = _Velocity * delta;
        MoveAndCollide(rel);
    }

    public void Yeet(Vector2 spawnLocation)
    {
        GlobalPosition = spawnLocation;
        _Velocity = _InitialVelocity;
    }
}
