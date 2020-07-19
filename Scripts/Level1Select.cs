using Godot;
using System;

public class Level1Select : CustomMenuButton
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _on_Level1Select_pressed()
	{
		GD.Print("Emit singal");
		EmitSignal(nameof(ButtonPressed), this._NextScene);
		// Replace with function body.
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
