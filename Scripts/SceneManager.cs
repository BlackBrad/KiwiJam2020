using Godot;
using System;

// Copied from Godot Docs:
// https://docs.godotengine.org/en/stable/getting_started/step_by_step/singletons_autoload.html
public class SceneManager : Node
{
    public Node CurrentScene { get; set; }
    private string _CurrentSceneName;

    public override void _Ready()
    {
        Viewport root = GetTree().GetRoot();
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
        _CurrentSceneName = CurrentScene.GetName();
    }

    public void GotoScene(string name)
    {
        // This function will usually be called from a signal callback,
        // or some other function from the current scene.
        // Deleting the current scene at this point is
        // a bad idea, because it may still be executing code.
        // This will result in a crash or unexpected behavior.

        // The solution is to defer the load to a later time, when
        // we can be sure that no code from the current scene is running:

        CallDeferred(nameof(DeferredGotoScene), name);
    }

    public void DeferredGotoScene(string name)
    {
        var path = "res://Scenes/" + name + ".tscn";
        GD.Print("Loading scene from ", path);
        // It is now safe to remove the current scene
        CurrentScene.Free();

        // Load a new scene.
        var nextScene = (PackedScene)GD.Load(path);

        // Instance the new scene.
        CurrentScene = nextScene.Instance();
        _CurrentSceneName = CurrentScene.GetName();

        // Add it to the active scene, as child of root.
        GetTree().GetRoot().AddChild(CurrentScene);

        // Optionally, to make it compatible with the SceneTree.change_scene() API.
        GetTree().SetCurrentScene(CurrentScene);
    }

    public void ReloadCurrentScene()
    {
        GotoScene(_CurrentSceneName);
    }
}
