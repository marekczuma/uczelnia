using UnityEngine;
using System.Collections;

public class BottleScript : MonoBehaviour {
	float lifeTime = 5;
	public float changePosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		lifeTime -= Time.fixedDeltaTime;
		if(lifeTime <=0)
		{
			Destroy(this.gameObject);
		}

		Vector3 tmpPos = this.transform.position;
		tmpPos.x -= changePosition;
		this.transform.position = tmpPos;
	}
}
