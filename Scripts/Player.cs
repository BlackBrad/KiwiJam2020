using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Vector2 m_Velocity = new Vector2();

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
		direction *= walkSpeed;

		float gravity = 400.0f;

		m_Velocity += new Vector2(direction, gravity * delta);

        float friction = 32.0f;
        m_Velocity.x -= m_Velocity.x * friction * delta;

		m_Velocity = MoveAndSlide(m_Velocity, new Vector2(0, -1));

        if (IsOnFloor())
        {
            m_Velocity.y = 0.0f;
            if (Input.IsActionJustPressed("jump"))
            {
                m_Velocity.y += -300.0f;
            }
        }

	}
}
