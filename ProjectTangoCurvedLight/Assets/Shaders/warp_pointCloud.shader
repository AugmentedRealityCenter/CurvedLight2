﻿Shader "Custom/warp_pointCloud" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		point_size("Point Size", Float) = 5.0
	}
	SubShader {
			Cull off
			Pass {
			Name "Custom/warp"
			Lighting On
		
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
            #include "UnityCG.cginc"         
                
            sampler2D _MainTex;
            float point_size;
               
            struct v2f
		    {
		        float4 pos : POSITION; // position
		        float3 color : COLOR;  // color
		        float2  uv : TEXCOORD0;// texture
		        float psize: PSIZE; //point size
		    }; 

			float4 _MainTex_ST;
			
			v2f vert (appdata_base v)
			{
			    v2f o;

				//Language reference is at: http://http.developer.nvidia.com/CgTutorial/cg_tutorial_appendix_e.html

				////////////////Begin warping
				//We will do all our work in camera space
				//Get the original vertex, in camera space
				//transform position from object space to eye space
				const float4 w = mul( UNITY_MATRIX_MV, v.vertex); //model and view
				
				////WARPING ALGORITHM STARTS HERE
				//w_mag appears to be correct // Get the original distnace of the vertex from camera
				const float w_mag = length(w);
				const float4 camera_direction = float4(0.0,0.0,-w_mag,1.0);
				
				 float warp_amount = min(w_mag/20.0, 1.0);
				 if(w.z > 0.0){
				  warp_amount = 0.0;
				  }
				//warp_amount = 0.0; //COMMENT/UNCOMMENT TO CHANGE WHETHER WARPING OR NOTs
				const float4 w_warped = lerp(w,camera_direction,warp_amount); 
				//const float4 w_warped = w_mag * normalize(lerp(w,camera_direction,warp_amount)); // (1- warp_amount) * w + warp_amount * camera_direction				
			    ////WARPING ALGORITHM ENDS HERE
			    
			 
			    
			    o.pos = mul( UNITY_MATRIX_P, w_warped);//w_warped);
			    //end warping
			    
			    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
			    o.color = ShadeVertexLights(v.vertex, v.normal);
			    o.psize = point_size;
			    
			    return o;
			}
			
		
			

			float4 frag(v2f i) : COLOR
			{
			    half4 texcol = tex2D (_MainTex, i.uv);
			    texcol.rgb = texcol.rgb/2 + texcol.rgb * i.color;
			    return texcol;	 
			}

			ENDCG
		}
	}
	
	FallBack "Diffuse"
}