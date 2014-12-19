using UnityEngine;
using System.Collections;

public class DeleteParticle : MonoBehaviour {
	float time = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time -= Time.fixedDeltaTime;
		if(time <=0)
		{
			Destroy(this.gameObject);
		}
	}
}
