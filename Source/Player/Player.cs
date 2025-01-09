using Godot;

public partial class Player : CharacterBody2D
{
	const float HandRange = 25.0f;

	public float speed = 250.0f;

	public override void _PhysicsProcess(double delta)
	{
		float weight = (float)delta * 10.0f;

		{ // Player movement.
			Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down").Normalized();
			Velocity = Velocity.Lerp(direction * speed, weight);
		}

		{ // Player hand logic.
			Marker2D hand = GetNode<Marker2D>("Hand");
			Vector2 distance = GetViewport().GetMousePosition() - GlobalPosition;
			Vector2 goal = (distance.Length() > HandRange) ? distance.Normalized() * HandRange : distance;
			hand.Position = hand.Position.Lerp(goal, weight);
		}

		MoveAndSlide();
	}
}
