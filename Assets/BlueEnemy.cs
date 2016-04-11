using UnityEngine;
using System.Collections;

public class BlueEnemy : MonoBehaviour {
	private bool isActivated = false;
	private bool isEatable = false;

	private int currentMode = 0;
	private Vector3 previousPlayerPosi = new Vector3(0,0,0);

	public Transform enemyRed;

	// Use this for initialization
	void Start () {
		//Set up the variable you need

	}

	public void activate () {
		//Start to move
		//Ghosts always move to the left as soon as they leave the ghost house, but they may reverse direction almost immediately due to an effect that will be described later.
		isActivated = true;
		transform.position = new Vector3 (-0.95f, 0.0f, 2.95f);
	}


	// Update is called once per frame
	void Update () {
		if (!isActivated)
			return;
		if (currentMode == 1) {
			//Attacking
			attack();
		}else if (currentMode == 2) {
			frightened ();
		}else if (currentMode == 3) {
			scatter ();
		}

		// The way to setup the nevigation
		// NavMeshAgent agent = GetComponent<NavMeshAgent>();
		// agent.destination = 
		// agent.velocity = new Vector3 (5,5,0); //This is to make it move at constant speed

	}

	public void setDestination (Vector3 destination) {

	}

	public void setMode (int mode) {
		currentMode = mode;
		// 1 attack
		// 2 Frightened mode is unique because the ghosts do not have a specific target tile while in this mode. Instead, they pseudorandomly decide which turns to make at every intersection.
		// 3 Going Arround
		// when switching mode they are forced to reverse direction as soon as they enter the next tile.
	}

	public void setIsEatable(bool isEatable){
		this.isEatable = isEatable;
	}

	public bool getIsActivated(){
		return isActivated;
	}

	private void attack (){
		//get the player's position
		Vector3 playerPosi =  GameObject.FindGameObjectWithTag ("Player").transform.position;

		//get the red ball's position
		Vector3 redPosi = enemyRed.position;

		//calculate the actual target
		Vector3 currentPosi =  transform.position;

		//Calculating the direction
		Vector3 tempDirection = playerPosi - previousPlayerPosi;

		if (tempDirection.x > 0) {
			playerPosi.x += 2;
		}else if (tempDirection.z > 0) {
			playerPosi.z += 2;
		}

		Vector3 target = new Vector3 (playerPosi.x,playerPosi.y,playerPosi.z);
		//target = target + 2 * (playerPosi - redPosi);
		target.x += (redPosi.x-playerPosi.x);
		target.z += (redPosi.z-playerPosi.z);

		//set the movement
		moveTo(target);
	}

	private void frightened(){
		
	}

	private void scatter(){
		// Going Around function
	}

	private void moveTo(Vector3 target){
		 NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = target;
		 agent.velocity = new Vector3 (5,0,5); //This is to make it move at constant speed
	}
}
