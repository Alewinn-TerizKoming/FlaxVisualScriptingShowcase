
namespace Game;

using FlaxEngine;

public class InteractionManager : Script
{
    public Camera Camera;

    public float Range = 200f;
    public LayersMask Mask = LayersMask.Default;

    private InteractionManagerUI _ui;
    private OutlineRenderer _renderer;

    private Interactable _current;
    private Interactable _previous;

    public override void OnAwake()
    {
        base.OnAwake();
        _ui = Actor.GetScript<InteractionManagerUI>();
        _renderer = Camera.GetScript<OutlineRenderer>();
    }

    public override void OnUpdate()
    {
        RayCastHit infos = new RayCastHit();

        var hit = Physics.RayCast(
            Camera.Position,
            Camera.Transform.Forward,
            out infos,
            Range,
            Mask
        );

        _previous = _current;
        _current = null;

        if (hit && infos.Collider)
        {
            _current = infos.Collider.Parent?.GetScript<Interactable>();

            // The Interaction have already been played
            if (_current!= null && _current.IsActivated)
            {
                _current = null;
                if(_previous != null)
                    _renderer.Actors.Remove(_previous.Actor);
                return;
            }
        }

        // Focus handling
        if (_previous != null)
        {
            _previous.IsActivated = false;
            _previous.IsInSight = false;

            if(_renderer && _renderer.Actors.Contains(_previous.Actor))
                _renderer.Actors.Remove(_previous.Actor);
        }
            
        if (_current != null && !_current.IsActivated)
        {
            _ui?.Show(_current.Prompt);

            if(_renderer && !_renderer.Actors.Contains(_current.Actor))
                _renderer?.Actors.Add(_current.Actor);
        }
        else
        {
            _ui?.Hide();
            if(_renderer && _renderer.Actors.Count>0)
            {
                if (_renderer.Actors.Contains(_current.Actor))
                    _renderer.Actors.Remove(_current.Actor);

                if (_renderer.Actors.Contains(_previous.Actor))
                    _renderer.Actors.Remove(_previous.Actor);
            }
        }

        // Input
        if (_current != null && !_current.IsActivated)
        {
            _current.IsInSight = true;

            if(Input.GetMouseButton(MouseButton.Left))
            {
                _current.IsActivated = true;
            }
        }
    }
}
