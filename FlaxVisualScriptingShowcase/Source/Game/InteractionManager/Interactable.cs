using FlaxEngine;
using System;

namespace Game;

/// <summary>
/// Interactable class.
/// C# to Visual editor interactions.
/// </summary>
[Unmanaged]
public class Interactable : Script
{
    public string Prompt = "Interact";

    [MultilineText]
    public string Description = "This is a default description";

    private bool _insight;

    [HideInEditor]
    public bool IsInSight 
    {
        get { return _insight; }
        set
        {
            if (_insight != value)
            {
                _insight = value;
            }
        }
    }

    [HideInEditor]
    public bool IsActivated;

    // Below are things that are not supported yet (1.12)
    //---------------------------------------------------

    // 1.12 - If you uncomment, it will break at runtime
    // If you bind something on it inside the Visual editor
    //[Unmanaged]   // 1.12 : use [Unmanaged] to see in visual editor
    //public event Action OnSomeDelegate;

    // 1.12 - If you uncomment and override it inside a 
    // visual script, it should fail silently (will
    // do nothing). The engine part that generates 
    // dynamic code bindings isn't working yet (at less
    // for this use case)
    //[Unmanaged]
    //public virtual void SomeOverridableMethod()
    //{
    //    Debug.Log("Hello, overridable method!");
    //}
}