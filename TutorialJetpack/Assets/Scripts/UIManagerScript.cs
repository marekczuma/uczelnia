using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {
	public Animator startButton;
	public Animator settingsButton;
	// Use this for initialization
	void Start () {
	
	}
	public void OpenSettings()
	{
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
