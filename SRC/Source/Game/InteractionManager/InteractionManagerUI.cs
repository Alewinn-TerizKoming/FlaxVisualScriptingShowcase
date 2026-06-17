using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

/// <summary>
/// InteractionManagerUI Script.
/// </summary>
public class InteractionManagerUI : Script
{
    public ControlReference<Label> PromptLabel;
    public ControlReference<Label> Cross;

    public override void OnAwake()
    {
        Hide();
    }

    public void Show(string text)
    {
        Cross.Control.Visible = false;
        PromptLabel.Control.Visible = true;
        PromptLabel.Control.Text = text;
    }

    public void Hide()
    {
        PromptLabel.Control.Visible = false;
        Cross.Control.Visible = true;
    }
}
