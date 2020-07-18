using Godot;
using System;

public class Dough : Area2D
{
    [Export]
    public float _Speed = 4.0f;

	public override void _PhysicsProcess(float delta)
	{
		var p = GlobalPosition;
		p.y -= _Speed * delta;
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
