using UnityEngine;
using System.Collections;

public class CreatingParticleSortingLayerFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.renderer.sortingLayerName = "Player";
		gameObject.renderer.sortingOrder = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
