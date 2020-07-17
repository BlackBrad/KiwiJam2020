using Godot;
using System;

public class SafeZone : Area2D
{
    private void _OnBodyEntered(object body)
    {
        if (body is Player)
        {
			GD.Print("Player entered safe zone");
			// TODO: Transition to next level
        }
    }
}
