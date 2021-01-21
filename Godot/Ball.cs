using Godot;
using System;




public class Ball : KinematicBody
{
    private int speed = 20;
    private Vector3 velocity = new Vector3(0,0,0) ;
    private Vector3 gravitydown = new Vector3(0,-1,0) * 12 ;
    private Vector3 gravityup = new Vector3(0, 1, 0) * 12;


    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Hello");
        
    }
   

    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

        velocity += gravitydown * delta;
        get_input();
        velocity = MoveAndSlide(velocity, gravityup);



    }
    public void get_input()
    {
        
        if (Input.IsActionPressed("ui_right") && Input.IsActionPressed("ui_left"))
        {
            velocity.x = 0;
        }
        else if (Input.IsActionPressed("ui_right"))
        {
            velocity.x = speed;
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            velocity.x = -speed;
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0, (float)0.1);
        }

        if (Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_down"))
        {
            velocity.x = 0;
        }
        else if (Input.IsActionPressed("ui_up"))
        {
            velocity.z = -speed;
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            velocity.z = speed;
        }
        else
        {
            velocity.z = Mathf.Lerp(velocity.z, 0, (float)0.1);
        }

        

    }
}
