﻿using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.Serialization;

// https://answer.uwa4d.com/question/5fa5040fdc477370c2c1f080
public class GrabPassFeature : ScriptableRendererFeature {
    [System.Serializable]
    public class GrabSettings {
        public Downsampling downSample = Downsampling._2xBilinear;
        public Material material;
    }

    public class GrabPass : CopyColorPass {
        private RenderTargetHandle to;

        public GrabPass(RenderPassEvent renderEvent, Material material, string profilerTag = "_GrabPass") : base(renderEvent, material, profilerTag) {
            to.id = Shader.PropertyToID(profilerTag);
        }

        public void Setup(RenderTargetIdentifier from, Downsampling sample) {
            base.Setup(from, to, sample);
        }
    }

    public RenderPassEvent renderEvent = RenderPassEvent.BeforeRenderingPostProcessing;
    public GrabSettings settings;

    private GrabPass pass;

    public override void Create() {
        pass = new GrabPass(renderEvent, settings.material);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) {
        pass.Setup(renderer.cameraColorTarget, settings.downSample);
        renderer.EnqueuePass(pass);
    }
}
