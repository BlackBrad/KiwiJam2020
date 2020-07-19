using Godot;
using System;

public class SafeZone : Area2D
{
	[Export]
	private string _NextLevel = "TestLevel";

	private void _OnBodyEntered(object body)
	{
		if (body is Player)
		{
			GD.Print("Player entered safe zone");
			var sceneManager = (SceneManager)GetNode("/root/SceneManager");
			sceneManager.GotoScene("LevelSelect");
		}
	}
}
