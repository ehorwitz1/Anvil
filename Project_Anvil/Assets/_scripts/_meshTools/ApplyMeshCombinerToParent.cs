using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMeshCombinerToParent : MonoBehaviour {

	void Start () {
		LocalMeshCombiner mc = GameObject.FindGameObjectWithTag( "MeshCombiner" ).GetComponent<LocalMeshCombiner>();
		mc.ApplyToMapTile( gameObject.transform.parent.gameObject );
	}

}
