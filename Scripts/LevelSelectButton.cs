using Godot;
using System;

public class LevelSelectButton : CustomMenuButton
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	
	private void _on_LevelSelectButton_focus_entered()
	{
		GetNode<KinematicBody2D>("YeetedCat").Show();
	}
	
	
	private void _on_LevelSelectButton_focus_exited()
	{
		GetNode<KinematicBody2D>("YeetedCat").Hide();
	}
}



