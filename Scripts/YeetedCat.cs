using Godot;
using System;

public class YeetedCat : KinematicBody2D
{
	private Vector2 _Velocity = new Vector2();

	[Export]
	private Vector2 _InitialVelocity = new Vector2();

	private AudioStreamPlayer2D _AudioStreamPlayer;

	public override void _Ready()
	{
		_AudioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");

		_AudioStreamPlayer.PitchScale = (float)GD.RandRange(0.9f, 1.1f);
		_AudioStreamPlayer.VolumeDb = (float)GD.RandRange(0.9f, 1.2f);
	}

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
