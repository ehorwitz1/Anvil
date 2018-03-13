using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachNavMeshSourceTag : MonoBehaviour {
	
    void Start(){
        if( gameObject.GetComponentInParent<NavMeshSourceTag>() == null ){
            transform.parent.gameObject.AddComponent<NavMeshSourceTag>();
        }
    }
}