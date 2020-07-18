using Godot;
using System;

public class NewGameButton : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	private string _NextScene = "";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	
	private void _on_NewGameButton_pressed()
	{
		var sceneManager = (SceneManager)GetNode("/root/SceneManager");
		sceneManager.GotoScene(_NextScene);
		// Replace with function body.
	}
}
