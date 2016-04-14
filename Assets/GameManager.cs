using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public static GameManager gm;
	public int score=0;
	public int blobscount;
	public Text mainScoreDisplay;
	public Transform em;
	private EnemyManager emManager;
	public Text gamefinish;
	public Text replay;
	public bool replayable = false;
	public AudioSource bgm;
	public AudioSource pacmanDie;
	public AudioSource playerWin;
	public void GameOver() {
		Time.timeScale = 0;
		gamefinish.text = "Game Over!";
		bgm.Stop ();
		pacmanDie.Play ();
		replay.text = "Hit 'R' to replay";
		replayable = true;
	}
	public void YouWin(){
		Time.timeScale = 0;
		gamefinish.text = "You Win!";
		bgm.Stop ();
		playerWin.Play ();
		replay.text = "Hit 'R' to replay";
		replayable = true;
	}
	// Use this for initialization
	void Start () {
		bgm.Play ();
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();
		emManager = em.GetComponent<EnemyManager> ();

		blobscount = 246;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R) && replayable == true) {
			Application.LoadLevel (Application.loadedLevel);
			Time.timeScale = 1;
		}
		if (blobscount == 0)
			YouWin ();
	}
	public void targetHit (int scoreAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		blobscount--;
		mainScoreDisplay.text = score.ToString ();
		emManager.updateScore (score);
		// if eat the special food, call em.onEatSpecialFood
	}
}
