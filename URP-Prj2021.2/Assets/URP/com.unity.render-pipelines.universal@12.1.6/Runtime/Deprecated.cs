// This file should be used as a container for things on its
// way to being deprecated and removed in future releases
using System;
using System.ComponentModel;

namespace UnityEngine.Rendering.Universal
{
    public abstract partial class ScriptableRenderPass
    {
        // This callback method will be removed. Please use OnCameraCleanup() instead.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void FrameCleanup(CommandBuffer cmd) => OnCameraCleanup(cmd);
    }
    
    namespace Internal
    {
        public partial class AdditionalLightsShadowCasterPass
        {
        }
    }
    public partial class UniversalRenderPipelineAsset
    {
    }

    public abstract partial class ScriptableRenderer
    {
    }
}
