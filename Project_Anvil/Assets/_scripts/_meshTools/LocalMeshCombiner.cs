using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMeshCombiner : MonoBehaviour {
	
	public void ApplyToMapTile( GameObject tile ){
		MeshFilter[] mf = tile.GetComponentsInChildren<MeshFilter>();
		int nMeshes = mf.Length;
		CombineInstance[] meshes = new CombineInstance[ nMeshes ];
		for( int i = 0; i < nMeshes; i++ ){
			Mesh currMesh = mf[i].mesh;
			meshes[i].mesh = new Mesh();
			meshes[i].mesh.vertices = currMesh.vertices;
			meshes[i].mesh.triangles = currMesh.triangles;
			meshes[i].mesh.uv = currMesh.uv;
			meshes[i].mesh.normals = currMesh.normals;
			meshes[i].mesh.colors = currMesh.colors;
			meshes[i].mesh.tangents = currMesh.tangents;
			meshes[i].transform = mf[i].transform.localToWorldMatrix;
			Debug.Log("Transform: " + meshes[i].transform );

		}

		GameObject combinedMeshHolder = GameObject.FindGameObjectWithTag("CombinedMeshContainer");
		GameObject co = new GameObject();
		co.name = "CombinedMesh ( " + tile.name + " )";
		co.AddComponent<MeshRenderer>();
		co.GetComponent<MeshRenderer>().enabled = false;
		co.AddComponent<MeshFilter>();
		co.GetComponent<MeshFilter>().mesh.CombineMeshes( meshes, true );
		co.transform.parent = combinedMeshHolder.transform;
		co.AddComponent<NavMeshSourceTag>();

	}


	
}
