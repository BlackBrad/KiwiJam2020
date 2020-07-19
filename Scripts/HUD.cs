using Godot;
using System;

public class HUD : CanvasLayer
{
    private Godot.Label _CatCountLabel;
    private Godot.Label _TimeLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _CatCountLabel = GetNode<Godot.Label>("Control/CatCountLabel");
        _TimeLabel = GetNode<Godot.Label>("Control/TimeLabel");
    }

    public void UpdateCatCount(int count)
    {
        _CatCountLabel.Text = "Cat Count: " + count;
    }

    public void UpdateTimeTaken(double time)
    {
        int minutes = (int)(time / 60.0f);
        int seconds = (int)(time - minutes * 60.0f);

        double remainder = time - (double)Mathf.Floor((float)time);
        int milliseconds = (int)(remainder * 1000);
        _TimeLabel.Text = "Level Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") +
            ":" + milliseconds.ToString("000");
    }
}
