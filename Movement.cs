using Godot;
using System;

public class Movement : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export] public int speed=200;
	
	public void GetInput()
	{
		velocity = Vector2();
		if (Input.isActionPressed("right")) 
			velocity.x += 1;
		if (Input.isActionPressed("left"))
			velocity.x -= 1;
		
		velocity = velocity.Normalized() * speed;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetInput();
		velocity = MoveAndSlide(velocity);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
