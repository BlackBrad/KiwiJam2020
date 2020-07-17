using Godot;
using System;

public class Dough : Area2D
{
	public override void _PhysicsProcess(float delta)
	{
		float riseRate = 4.0f;
		var p = GlobalPosition;
		p.y -= riseRate * delta;
		GlobalPosition = p;
	}

	private void _OnBodyEntered(object body)
	{
		if (body is Player)
		{
			GD.Print("Fell into the sour dough");
			var sceneManager = GetNode<SceneManager>("/root/SceneManager");
			sceneManager.ReloadCurrentScene();
		}
	}

}
