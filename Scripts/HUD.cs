using Godot;
using System;

public class HUD : CanvasLayer
{
    private Label _CatCountLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _CatCountLabel = GetNode<Label>("Control/CatCountLabel");
    }

    public void SetCatCount(int count)
    {
        _CatCountLabel.Text = "Cat Count: " + count;
    }
}
