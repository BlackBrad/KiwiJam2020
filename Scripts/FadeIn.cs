using Godot;
using System;

public class FadeIn : ColorRect
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Signal]
	public delegate void FadeFinished();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	public void FadeMeIn(){
		AnimationPlayer anim = GetNode<AnimationPlayer>("AnimationPlayer");
		anim.Play("MenuFadeIn");
	}

	
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		EmitSignal(nameof(FadeFinished));
		// Replace with function body.
	}
}


