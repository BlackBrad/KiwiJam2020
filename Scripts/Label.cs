using Godot;
using System;

public class Label : Godot.Label
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Color _NormalColor = new Color(1f,0.59f,0f,1f);
	Color _HoverColor = new Color(1f,0f,0f,1f);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_CustomMenuButton_focus_entered()
	{
		this.Set("custom_colors/font_color_shadow", this._HoverColor);
		this.SetScale(new Vector2(1.05f, 1.05f));
		// Replace with function body.
	}
	
	
	private void _on_CustomMenuButton_focus_exited()
	{
		this.Set("custom_colors/font_color_shadow", this._NormalColor);
		this.SetScale(new Vector2(1f, 1f));
		// Replace with function body.
	}
	
	
	private void _on_CustomMenuButton_mouse_entered()
	{
		GetOwner<Button>().GrabFocus();
		// Replace with function body.
	}
}



