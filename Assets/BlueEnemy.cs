using UnityEngine;
using System.Collections;

public class BlueEnemy : MonoBehaviour {
	
	NavMeshAgent agent;
	public Transform idle1,idle2,idle3,idle4,idle5,idle6,idle7,idle8;
	public Vector3[] idles;
	private int currentIdle = 0;
	private bool isActivated = false;
	private bool isEatable = false;
	private int mode;
	private Vector3 previousPlayerPosi = new Vector3(0,0,0);
	public Transform enemyRed;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		// Cache agent component and destination
		idles = new Vector3[8];
		idles [0] = new Vector3(idle1.position.x,0,idle1.position.z);
		idles [1] = new Vector3(idle2.position.x,0,idle2.position.z);
		idles [2] = new Vector3(idle3.position.x,0,idle3.position.z);
		idles [3] = new Vector3(idle4.position.x,0,idle4.position.z);
		idles [4] = new Vector3(idle5.position.x,0,idle5.position.z);
		idles [5] = new Vector3(idle6.position.x,0,idle6.position.z);
		idles [6] = new Vector3(idle7.position.x,0,idle7.position.z);
		idles [7] = new Vector3(idle8.position.x,0,idle8.position.z);

	}

	public void activate () {
		//Start to move
		//Ghosts always move to the left as soon as they leave the ghost house, but they may reverse direction almost immediately due to an effect that will be described later.
		isActivated = true;
		//transform.position = new Vector3 (-0.95f, 0.0f, 2.95f);
	}


	// Update is called once per frame
	void Update () {
		if (!isActivated)
			return;
		
		if (mode == 1) {
			//Attacking
			attack();
		}else if (mode == 2) {
			frightened ();
		}else if (mode == 3) {
			scatter ();
		}

		// The way to setup the nevigation
		// NavMeshAgent agent = GetComponent<NavMeshAgent>();
		// agent.destination = 
		// agent.velocity = new Vector3 (5,5,0); //This is to make it move at constant speed

	}

	public void setDestination (Vector3 destination) {

	}

	public void setMode (int Mode) {
		mode = Mode;
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
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && isEatable == true) {
			Destroy (gameObject);
			GameManager.gm.targetHit (20);
		} else if (other.gameObject.tag == "Player" && isEatable == false)
			Application.LoadLevel ("GameOver");

	}
	private void frightened(){
		startFrighten();
	}

	private void scatter(){
		// Going Around function
		if ((Vector3.Distance (agent.transform.position, idles [currentIdle])) < 1) {
			currentIdle++;
			if (currentIdle == 8)
				currentIdle = 0;
		}
		agent.destination = idles [currentIdle];
	}

	private void moveTo(Vector3 target){
		agent.destination = target;
		//agent.velocity = new Vector3 (5,0,5); //This is to make it move at constant speed
	}

	public void startFrighten(){
		if (mode != 2)
			return;
		currentTarget = new Vector3 (Random.Range(-17.5F, 19.5F),0F,Random.Range(-37.9F, 10.25251F));
		agent.destination = currentTarget;
		Invoke ("startFrighten", 5F);
	}
}
