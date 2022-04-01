Shader "Hidden/Universal/CoreBlitColorAndDepth"
{
    HLSLINCLUDE

        #pragma target 2.0
        #pragma editor_sync_compilation
        #pragma multi_compile _ DISABLE_TEXTURE2D_X_ARRAY
        #pragma multi_compile _ BLIT_SINGLE_SLICE
        // Core.hlsl for XR dependencies
        #include "Assets/URP/com.unity.render-pipelines.universal@12.1.6/ShaderLibrary/Core.hlsl"
        #include "Assets/URP/com.unity.render-pipelines.core@12.1.6/Runtime/Utilities/BlitColorAndDepth.hlsl"
    ENDHLSL

    SubShader
    {
        Tags{ "RenderPipeline" = "UniversalPipeline" }

        // 0: Color Only
        Pass
        {
            ZWrite Off ZTest Always Blend Off Cull Off

            HLSLPROGRAM
                #pragma vertex Vert
                #pragma fragment FragColorOnly
            ENDHLSL
        }

        // 1:  Color Only and Depth
        Pass
        {
            ZWrite On ZTest Always Blend Off Cull Off

            HLSLPROGRAM
                #pragma vertex Vert
                #pragma fragment FragColorAndDepth
            ENDHLSL
        }

    }

    Fallback Off
}
