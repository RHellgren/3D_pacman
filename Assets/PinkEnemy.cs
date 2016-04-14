using UnityEngine;
using System.Collections;

public class PinkEnemy : MonoBehaviour {

	NavMeshAgent agent;
	public Transform idle1,idle2,idle3,idle4;
	public Vector3[] idles;
	private int currentIdle = 0;
	private bool isActivated = false;
	private bool isEatable = false;
	private bool isFrightening = false;
	private int mode;
	private Vector3 previousPlayerPosition;
	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

		idles = new Vector3[4];
		idles [0] = new Vector3(idle1.position.x,0,idle1.position.z);
		idles [1] = new Vector3(idle2.position.x,0,idle2.position.z);
		idles [2] = new Vector3(idle3.position.x,0,idle3.position.z);
		idles [3] = new Vector3(idle4.position.x,0,idle4.position.z);
	}

	public void activate () {
		//Start to move
		isActivated = true;
	}

	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && isEatable == true) {
			//Destroy (gameObject);
			resetEnemy();
			GameManager.gm.targetHit (20);
		} else if (other.gameObject.tag == "Player" && isEatable == false)
			Application.LoadLevel ("GameOver");

	}
	// Update is called once per frame
	void Update () {
		if (!isActivated)
			return;

		Vector3 newPosition = new Vector3(0,0,0);
		if (mode == 1) {	// attack
			newPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			float differenceX = previousPlayerPosition.x - newPosition.x;
			float differenceZ = previousPlayerPosition.z - newPosition.z;
			newPosition.x += (differenceX * 10);
			newPosition.z += (differenceZ * 10);
			agent.destination = newPosition;
			previousPlayerPosition = newPosition;
		} else if (mode == 2) { // frightened
			if (!isFrightening)
				startFrighten();
			isFrightening = true;
		} else if (mode == 3) { // Going around
			if ((Vector3.Distance (agent.transform.position, idles [currentIdle])) < 1) {
				currentIdle++;
				if (currentIdle == 4)
					currentIdle = 0;
			}
			agent.destination = idles [currentIdle];
		}
	}

	public void setDestination (Vector3 destination) {
		agent.destination = destination;
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

	public void startFrighten(){
		if (mode != 2) {
			isFrightening = false;
			return;
		}
		currentTarget = new Vector3 (Random.Range(-17.5F, 19.5F),0F,Random.Range(-37.9F, 10.25251F));
		agent.destination = currentTarget;
		Invoke ("startFrighten", 5F);
	}

	private void resetEnemy(){
		transform.position = new Vector3 (-0.8F,0F,-2.75F);
	}
}
