using Godot;
using projetogodotvampcast.Script.Entity.PlayerFriendly;

namespace projetogodotvampcast.Script.Drop;
[GlobalClass]
public partial class Dropable : Area2D
{
	[Export]
	public float Weight { get; set; } = 1.0f;
	[Export]
	public bool OnlyPlayerPick { get; set; }

    private float _velocity = 0;
    private float _gravity = 400f;
    private bool _onGround = false;

	private RayCast2D _floor_raycast = null;

    public override void _Ready()
	{
		_floor_raycast = GetNode<RayCast2D>("FloorRaycast");
        this.BodyEntered += _CharacterPicking;
	}

	public override void _Process(double delta)
	{
		if (_onGround) return;

        _velocity += _gravity * Weight * (float)delta;
        Vector2 displacement = new Vector2(0, _velocity * (float)delta);

        if (_floor_raycast.IsColliding())
        {
            _onGround = true;
            _velocity = 0;

            GlobalPosition = new Vector2(GlobalPosition.X, _floor_raycast.GetCollisionPoint().Y);
            return;
        }

        Position += displacement;
    }

	public virtual void _CharacterPicking(Node other)
	{
		if (OnlyPlayerPick) if(other is not PlayerCharacter) GD.Print("Other is trying pick up de item...");
    }
}
