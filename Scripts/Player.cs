using Godot;
using System;

public class Player : KinematicBody2D
{
	private Vector2 _Velocity = new Vector2();

	private bool _WasOnGround = false;

	[Export]
	private float _GroundWalkSpeed = 250.0f;

	[Export]
	private float _AirWalkSpeed = 20.0f;

	[Export]
	private float _Gravity = 400.0f;

	[Export]
	private float _GroundFriction = 32.0f;

	[Export]
	private float _AirFriction = 4.0f;

	[Export]
	private float _JumpVelocity = 380.0f;

    [Export]
    private float _WallJumpVerticalVelocity = 380.0f;

    [Export]
    private float _WallJumpHorizontalVelocity = 400.0f;

    private float _CatCount = 0;

	private AnimationPlayer _AnimationPlayer;
	private Sprite _Sprite;
	private AnimationTree _AnimationTree;
	private AnimationNodeStateMachinePlayback _AnimStateMachine;
    private PackedScene _YeetedCatPrefab;
    private Timer _YeetedCatDelayTimer;

    private Node2D _RightWallRaycasts;
    private Node2D _LeftWallRaycasts;

	public override void _Ready()
	{
		_AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_Sprite = GetNode<Sprite>("Sprite");
		_AnimationTree = GetNode<AnimationTree>("AnimationTree");
        _YeetedCatDelayTimer = GetNode<Timer>("YeetedCatDelayTimer");

		_AnimStateMachine = (AnimationNodeStateMachinePlayback)
								_AnimationTree.Get("parameters/playback");

        _RightWallRaycasts = GetNode<Node2D>("RightWallRaycasts");
        _LeftWallRaycasts = GetNode<Node2D>("LeftWallRaycasts");

        _YeetedCatPrefab = (PackedScene)GD.Load("res://Scenes/YeetedCat.tscn");
	}

	public void ChangeAnimationState(string stateName)
	{
        if (_AnimStateMachine.GetCurrentNode() != stateName)
        {
            //GD.Print("ChangeAnimationState from: ",
                    //_AnimStateMachine.GetCurrentNode(),
                    //" to: ", stateName);

            _AnimStateMachine.Travel(stateName);
            //var path = _AnimStateMachine.GetTravelPath();
            //foreach (var segment in path)
            //{
                //GD.Print("-> ", segment);
            //}
        }
    }

    public bool WallRaycast(Node2D parent)
    {
        foreach (var child in parent.GetChildren())
        {
            var raycast = (RayCast2D)child;
            if (raycast.IsColliding())
            {
                return true;
            }
        }

        return false;
    }

	public void YeetCat()
	{
		// Only allow cat yeeting if player is in the air
		if (!IsOnFloor())
		{
            if (_YeetedCatDelayTimer.TimeLeft <= 0.0f)
            {
                ChangeAnimationState("AerialYeet");
                _YeetedCatDelayTimer.Start();
            }
		}
	}

    public void OnCatPickup()
    {
        _CatCount++;
    }

	public override void _PhysicsProcess(float delta)
	{
		float direction = 0.0f;
		if (Input.IsActionPressed("walk_left"))
		{
			direction = -1.0f;
			_Sprite.FlipH = true;
		}
		if (Input.IsActionPressed("walk_right"))
		{
			direction = 1.0f;
			_Sprite.FlipH = false;
		}

		if (_WasOnGround)
		{
			if (Mathf.Abs(direction) > 0.0f)
			{
				ChangeAnimationState("Run");
			}
			else
			{
				ChangeAnimationState("Idle");
			}

			_Velocity.y = 0.0f;
			if (Input.IsActionJustPressed("jump"))
			{
				_Velocity.y += -_JumpVelocity;
				ChangeAnimationState("JumpStart");
			}
		}
        else
        {
			ChangeAnimationState("Falling");
        }

		if (Input.IsActionJustPressed("yeet"))
		{
            if (_CatCount > 0)
            {
			    YeetCat();
                _CatCount--;
            }
		}

		float walkSpeed = _GroundWalkSpeed;
		float gravity = _Gravity;
		float friction = _GroundFriction;

		if (!_WasOnGround)
        {
            friction = _AirFriction;
            walkSpeed = _AirWalkSpeed;

            if (WallRaycast(_RightWallRaycasts))
            {
                if (Input.IsActionJustPressed("jump"))
                {
                    _Velocity.y = -_WallJumpVerticalVelocity;
                    _Velocity.x = -_WallJumpHorizontalVelocity;
                    _Sprite.FlipH = true;
                    ChangeAnimationState("JumpStart");
                }
            }
            else if (WallRaycast(_LeftWallRaycasts))
            {
                if (Input.IsActionJustPressed("jump"))
                {
                    _Velocity.y = -_WallJumpVerticalVelocity;
                    _Velocity.x = _WallJumpHorizontalVelocity;
                    _Sprite.FlipH = false;
                    ChangeAnimationState("JumpStart");
                }
            }

            // Jump height control
            if (Input.IsActionJustReleased("jump") && _Velocity.y < 0.0f)
            {
                _Velocity.y = 0.0f;
            }
        }

		direction *= walkSpeed;

		_Velocity += new Vector2(direction, gravity * delta);
		_Velocity.x -= _Velocity.x * friction * delta;
		_Velocity = MoveAndSlide(_Velocity, new Vector2(0, -1));

		_WasOnGround = IsOnFloor();
	}

    public void _OnYeetedCatDelayTimerTimeout()
    {
        _Velocity.y = -_JumpVelocity;

        var yeetedCat = (YeetedCat)_YeetedCatPrefab.Instance();
        GetNode("../").AddChild(yeetedCat);
        yeetedCat.Yeet(GlobalPosition);
        _YeetedCatDelayTimer.Stop();
    }
}
