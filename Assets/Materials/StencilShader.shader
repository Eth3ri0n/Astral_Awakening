// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

Shader "Unlit/StencilShader"
{
    Properties
    {
       [IntRange] _StencilID("StencilID", Range(0,15)) = 0
    }
    SubShader
    {
        Tags {  "RenderType" = "Opaque"
                "Queue" = "Geometry" 
                "RenderPipeline" = "UniversalPipeline"}
       

        Pass
        {
                Blend Zero One
                ZWrite Off

                Stencil
                {
                    Ref[_StencilID]
                    Comp Always
                    Pass Replace
                    Fail Keep
                }
        }
    }
}
