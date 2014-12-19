using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
	public float jetpackForce = 75.0f;
	public float forwardMovementSpeed = 3.0f;
	public Transform groundCheckTransform;
	public LayerMask groundCheckLayerMask;
	public ParticleSystem jetpack;
	public Texture2D coinIconTexture;
	public GameObject ButtonReturn;
	public GameObject highscoreText;
	public GameObject bloodParticle;
	public GameObject BNEParticle;
	public GameObject bottlePrefab;

	private bool grounded;
	private bool dead = false;
	private uint coins = 0;
	private int BNEAlbums = 0;
	private int BNEAlbumsRecord;
	private float tmpPosition = 0;
	private float bottleTime = 5;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		//PlayerPrefs.SetInt ("HighscoreBNE", 0);
		int tmpHighscore = PlayerPrefs.GetInt ("HighscoreBNE");
		BNEAlbumsRecord = tmpHighscore;
	}

	void FixedUpdate () 
	{
		int tmpPos = (int)(this.transform.position.x);
		if (tmpPos % 5 == 0)
		{
			forwardMovementSpeed += 0.008f;
		}
		bool jetpackActive = Input.GetButton("Fire1");
		
		jetpackActive = jetpackActive && !dead;
		
		if (jetpackActive)
		{
			rigidbody2D.AddForce(new Vector2(0, jetpackForce));
		}
		
		if (!dead)
		{
			Vector2 newVelocity = rigidbody2D.velocity;
			newVelocity.x = forwardMovementSpeed;
			rigidbody2D.velocity = newVelocity;
			createBottle();
		}
		
		UpdateGroundedStatus();
		
		AdjustJetpack(jetpackActive);
	}

	void DisplayCoinsCount()
	{
		Rect coinIconRect = new Rect(10, 10, 32, 32);
		GUI.DrawTexture(coinIconRect, coinIconTexture);                         
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;
		
		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, BNEAlbums.ToString(), style);
	}

	void UpdateGroundedStatus()
	{
		//1
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
		
		//2
		animator.SetBool("grounded", grounded);
	}
	void createBottle()
	{
		bottleTime -= Time.fixedDeltaTime;
		if(bottleTime <= 0)
		{
			Vector3 tmpPos = this.transform.position;
			tmpPos.x += 14;
			Instantiate(bottlePrefab, tmpPos, Quaternion.identity);
			bottleTime = 5;
		}
	}
	void AdjustJetpack (bool jetpackActive)
	{
		jetpack.enableEmission = !grounded;
		jetpack.emissionRate = jetpackActive ? 300.0f : 75.0f; 
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("BNEAlbum"))
			CollectBNEAlbum(collider);
		else
			HitByLaser(collider);
	}
	
	void HitByLaser(Collider2D laserCollider)
	{
		Instantiate (bloodParticle, this.transform.position, Quaternion.identity);
		dead = true;
		animator.SetBool("dead", true);
		Instantiate (ButtonReturn);
		if (BNEAlbums > BNEAlbumsRecord) 
		{
			BNEAlbumsRecord = BNEAlbums;
			Instantiate(highscoreText);
			PlayerPrefs.SetInt("HighscoreBNE", BNEAlbumsRecord);
		}
	}
	void CollectBNEAlbum(Collider2D coinCollider)
	{
		Instantiate (BNEParticle, this.transform.position, Quaternion.identity);
		BNEAlbums++;
		if (BNEAlbums == 40) 
		{
			AchievementScript.Achieve("40Albums");
		}else if(BNEAlbums == 400)
		{
			AchievementScript.Achieve("400Albums");
		}
		Destroy(coinCollider.gameObject);
	}
	void OnGUI()
	{
		DisplayCoinsCount();
	}
}
