using Godot;
using System;

public class CustomMenuButton : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	[Export]
	public string _NextScene = "";
	
	[Signal]
	public delegate void ButtonPressed(string nextLevel);
	
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	public void _on_CustomMenuButton_pressed()
	{
		EmitSignal(nameof(ButtonPressed), this._NextScene);
		// Replace with function body.
	}
}



