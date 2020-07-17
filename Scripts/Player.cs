using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Vector2 m_Velocity = new Vector2();

	private bool m_IsOnGround = false;

	[Export]
	private float _GroundWalkSpeed = 250.0f;

	[Export]
	private float _AirWalkSpeed = 180.0f;

	[Export]
	private float _Gravity = 400.0f;

	[Export]
	private float _GroundFriction = 32.0f;

	[Export]
	private float _AirFriction = 24.0f;

	[Export]
	private float _JumpVelocity = 380.0f;

	public override void _PhysicsProcess(float delta)
	{
		float direction = 0.0f;
		if (Input.IsActionPressed("walk_left"))
		{
			direction = -1.0f;
		}
		if (Input.IsActionPressed("walk_right"))
		{
			direction = 1.0f;
		}

		float walkSpeed = _GroundWalkSpeed;
		float gravity = _Gravity;
		float friction = _GroundFriction;

		if (!m_IsOnGround)
		{
			friction = _AirFriction;
			walkSpeed = _AirWalkSpeed;
		}
		direction *= walkSpeed;

		m_Velocity += new Vector2(direction, gravity * delta);
		m_Velocity.x -= m_Velocity.x * friction * delta;
		m_Velocity = MoveAndSlide(m_Velocity, new Vector2(0, -1));

		m_IsOnGround = IsOnFloor();
		if (IsOnFloor())
		{
			m_Velocity.y = 0.0f;
			if (Input.IsActionJustPressed("jump"))
			{
				m_Velocity.y += -_JumpVelocity;
			}
		}

	}

	private void _OnDoughEntered(object body)
	{
		GD.Print("Fell into the sour dough");
		GetTree().ReloadCurrentScene();
		// Replace with function body.
	}
}


