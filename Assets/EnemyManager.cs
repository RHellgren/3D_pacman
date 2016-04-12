using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public static EnemyManager em;
	public Transform enemyRed;
	public Transform enemyBlue;
	public Transform enemyPink;
	public Transform enemyOrange;

	private RedEnemy red;
	private BlueEnemy blue;
	private PinkEnemy pink;
	private OrangeEnemy orange;

	private int score = 0;

	private bool specialMode = false;
	private int speicalModeLength = 10;
	private int attackLength = 20;
	private int scatterLength = 7;


	// Use this for initialization
	void Start () {
		if (em == null) 
			em = this.gameObject.GetComponent<EnemyManager>();
		
		red = enemyRed.GetComponent<RedEnemy> ();
		blue = enemyBlue.GetComponent<BlueEnemy> ();
		pink = enemyPink.GetComponent<PinkEnemy> ();
		orange = enemyOrange.GetComponent<OrangeEnemy> ();

		red.activate ();
		//Set the basic mode into 3, going around
		setMode3();
	}
	
	// Update is called once per frame
	void Update () {
		//Activate the enemy when possible
		if (score >= 5 && !pink.getIsActivated()) {
			pink.activate ();
		}

		if (score >= 30 && !blue.getIsActivated()) {
			blue.activate ();
		}

		if (score >= 80 && !orange.getIsActivated()) {
			orange.activate ();
		}
	}

	public void onEatSpecialFood(){
		//involves change mode
		setMode2();
		red.setIsEatable (true);
		blue.setIsEatable (true);
		pink.setIsEatable (true);
		orange.setIsEatable (true);
	}

	//Functions for change mode

	public void updateScore(int score){
		this.score = score;
	}

	private void setMode1(){
		//Set to Attack mode
		if (!specialMode)
			updateAllAIMode(1);
		Invoke("setMode3", this.attackLength);
	}

	private void setMode2(){
		//Set to Frightend mode
		this.specialMode = true;
		updateAllAIMode(2);
		Invoke("endOfSpecialTime", this.speicalModeLength);
	}

	private void setMode3(){
		//Set to Going Around mode
		if (!specialMode)
			updateAllAIMode(3);
		Invoke("setMode1", this.scatterLength);
	}

	private void updateAllAIMode(int mode){
		red.setMode (mode);
		blue.setMode (mode);
		pink.setMode (mode);
		orange.setMode (mode);
	}

	private void endOfSpecialTime(){
		this.specialMode = false;
		red.setIsEatable (false);
		blue.setIsEatable (false);
		pink.setIsEatable (false);
		orange.setIsEatable (false);
		
		setMode1 ();
	}
}