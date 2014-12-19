using UnityEngine;
using System.Collections;

public class AchivementShowScript : MonoBehaviour {
	public Animator Ach;

	private bool wait = true;
	private bool isDown = false;
	private float tmpTime = 2.5f;
	// Use this for initialization
	void Start () {
		Ach.SetBool("isHidden", true);
	}
	void GoUp()
	{
		if(wait == true)
		{
			tmpTime -= Time.fixedDeltaTime;
			if(tmpTime <=0)
			{
				Ach.SetBool("isHidden", false);
			}
		}
	}
	void UpdateHidden()
	{
		if(this.transform.position.y <=51)
		{
			Ach.SetBool("isHidden", false);
			isDown = true;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if((Ach.GetBool("isHidden") == false) || (isDown == true))
		{
			wait = true;
		}
		UpdateHidden ();
		GoUp ();
	}
}
