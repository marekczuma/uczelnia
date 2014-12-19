using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AchievementScript : MonoBehaviour {
	static public List<Achievement> Achievements = new List<Achievement>();
	public GameObject Obj400Albums;
	public GameObject Obj40Albums;
	// Use this for initialization
	void Start () {
		Achievement Ach400Albums = new Achievement ("400Albums", "Collect 400 albums!", Obj400Albums);
		Achievements.Add (Ach400Albums);
		Achievement Ach40Albums = new Achievement ("40Albums", "Collect 40 albums!", Obj40Albums);
		Achievements.Add (Ach40Albums);
	}
	static public void Achieve(string name)
	{
		foreach (Achievement element in Achievements) 
		{
			if(element.Name == name)
			{
				element.Achieved = true;
				Instantiate(element.AchTexture);
			}

		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}

public class Achievement
{
	public string Name { get; set; }
	public string Description { get; set; }
	public bool Achieved {get; set;}
	public GameObject AchTexture {get; set;}
	public Achievement(string _name, string _description, GameObject _achTexture)
	{
		Name = _name;
		Description = _description;
		AchTexture = _achTexture;
		Achieved = false;
	}
}