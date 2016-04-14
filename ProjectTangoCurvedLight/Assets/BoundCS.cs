using UnityEngine;
using System.Collections;

public class BoundCS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshFilter[] allMeshes = GameObject.FindObjectsOfType(typeof(MeshFilter)) as MeshFilter[];
		//AndroidHelper.ShowAndroidToastMessage("Num meshes: "+allMeshes.Length);

		int count = 0;
		foreach (MeshFilter mesh in allMeshes)
		{
			count++;
			//AndroidHelper.ShowAndroidToastMessage("Num meshes: " + count);
			//var mesh : Mesh = t;
			//if(mesh){
				//mesh.bounds.Expand(Vector3(20000,20000,20000));
				//mesh.mesh.bounds.extents.Set(15000,15000,15000);

			mesh.mesh.bounds = new Bounds(new Vector3(0,0,0), new Vector3(2000,2000,2000));
			if(count == 1)
				AndroidHelper.ShowAndroidToastMessage("Num meshes: " + mesh.mesh.bounds.extents.x);
			//}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
