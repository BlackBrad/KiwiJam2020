using Godot;
using System;

public class TitleScreen : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private string queueScene = "";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<AnimatedSprite>("DoughLayer/Dough/AnimatedSprite").Hide();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _LevelChange(string nextLevel)
	{
		this.queueScene = nextLevel;
		FadeIn fadeIn = GetNode<FadeIn>("TopLayer/FadeIn");
		fadeIn.Show();
		fadeIn.FadeMeIn();
		
		// Replace with function body.
	}
	
	private void _on_FadeIn_FadeFinished()
	{
		var sceneManager = (SceneManager)GetNode("/root/SceneManager");
		sceneManager.GotoScene(this.queueScene);
		// Replace with function body.
	}
}
