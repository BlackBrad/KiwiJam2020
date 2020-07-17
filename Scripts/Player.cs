using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Vector2 m_Velocity = new Vector2();

	private bool m_IsOnGround = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	public void GetInput()
	{
	}

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

		float walkSpeed = 250.0f;
		float gravity = 400.0f;
		float friction = 32.0f;

		if (!m_IsOnGround)
		{
			friction = 24.0f;
			walkSpeed = 180.0f;
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
				m_Velocity.y += -380.0f;
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


