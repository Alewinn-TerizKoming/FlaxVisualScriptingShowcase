using System.Collections.Generic;
using FlaxEngine;

/// <summary>
/// Outline renderer from official Flax Doc example.
/// </summary>
public class OutlineRenderer : PostProcessEffect
{
    private MaterialInstance _material;

    /// <summary>
    /// The list of actors to render.
    /// </summary>
    public List<Actor> Actors = new List<Actor>();

    /// <summary>
    /// The outline color.
    /// </summary>
    public Color Color = Color.Red;

    /// <summary>
    /// The outline postfx material.
    /// </summary>
    public MaterialBase Material;

    /// <inheritdoc/>
    public override void OnEnable()
    {
        _material = Material?.CreateVirtualInstance();
    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        Destroy(ref _material);
    }

    /// <inheritdoc />
    public override bool CanRender()
    {
        return base.CanRender() && _material && Actors?.Count > 0;
    }

    /// <inheritdoc/>
    public override void Render(GPUContext context, ref RenderContext renderContext, GPUTexture input, GPUTexture output)
    {
        Profiler.BeginEventGPU("Outline");

        // Pick a temporary depth buffer
        var desc = GPUTextureDescription.New2D(input.Width, input.Height, PixelFormat.D32_Float, GPUTextureFlags.DepthStencil | GPUTextureFlags.ShaderResource);
        var customDepth = RenderTargetPool.Get(ref desc);
        context.ClearDepth(customDepth.View());

        // Draw objects to depth buffer
        Renderer.DrawSceneDepth(context, renderContext.Task, customDepth, Actors);

        // Render outline
        _material.SetParameterValue("OutlineColor", Color);
        _material.SetParameterValue("CustomDepth", customDepth);
        Renderer.DrawPostFxMaterial(context, ref renderContext, _material, output, input.View());

        // Cleanup
        RenderTargetPool.Release(customDepth);

        Profiler.EndEventGPU();
    }
}