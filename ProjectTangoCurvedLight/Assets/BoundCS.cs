using UnityEngine;
using System.Collections;

public class BoundCS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshFilter[] allMeshes = GameObject.FindObjectsOfType(typeof(MeshFilter)) as MeshFilter[];
		AndroidHelper.ShowAndroidToastMessage("Num meshes: "+allMeshes.Length);
		
		foreach (MeshFilter mesh in allMeshes)
		{
			//var mesh : Mesh = t;
			if(mesh && mesh.mesh){
				//mesh.bounds.Expand(Vector3(20000,20000,20000));
				mesh.mesh.bounds.extents.Set(15000,15000,15000); 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
