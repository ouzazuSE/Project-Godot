using Godot;
using System;
using static Godot.GD;


public class KinematicBody : Godot.KinematicBody

{
	
	private float gravity = -9.8f;
	private Vector3 velocity = new Vector3();

	private int speed = 6;
	private int acceleration = 3;
	private int de_acceleration = 5;
	private Vector3 direction = Vector3.Forward;

	private Transform move;

	public override void _Ready()
	{

	}


	public override void _PhysicsProcess(float delta)
	{
		var dir = new Vector3();

		if (Input.IsActionPressed("ui_up"))
		{
			
		}
		if (Input.IsActionPressed("ui_down"))
		{
			
		}
		if (Input.IsActionPressed("ui_left"))
		{
			
		}
		if (Input.IsActionPressed("ui_right"))
		{
			
		}

		if (Input.IsActionPressed("ui_up") || Input.IsActionPressed("ui_left") || Input.IsActionPressed("ui_right") ||
		    Input.IsActionPressed("ui_down"))
		{
			direction = new Vector3(Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"),0,Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up")).Normalized();
		}
		
		Rotation.y = Mathf.Atan2(-direction.x, -direction.z);
		
		dir.y = 0;
		dir = dir.Normalized();

		velocity.y += delta * gravity;

		var hv = velocity;
		hv.y = 0;

		var new_pos = dir * speed;
		var accel = de_acceleration;

		if (dir.Dot(hv) > 0)
		{
			accel = acceleration;
		}

		hv = hv.LinearInterpolate(new_pos, accel * delta);

		velocity.x = hv.x;
		velocity.z = hv.z;

		velocity = MoveAndSlide(velocity, new Vector3(0, 1, 0));
	}
	
}
