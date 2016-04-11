using UnityEngine;
using System.Collections;

public class RedEnemy : MonoBehaviour {

	private bool isActivated = false;
	private bool isEatable = false;

	// Use this for initialization
	void Start () {
		//Set up the variable you need
	
	}

	public void activate () {
		//Start to move
		//Ghosts always move to the left as soon as they leave the ghost house, but they may reverse direction almost immediately due to an effect that will be described later.
		isActivated = true;
	}

	
	// Update is called once per frame
	void Update () {
		// The way to setup the nevigation
		// NavMeshAgent agent = GetComponent<NavMeshAgent>();
		// agent.destination = 
		// agent.velocity = new Vector3 (5,5,0); //This is to make it move at constant speed
	}

	public void setDestination (Vector3 destination) {
		
	}

	public void setMode (int mode) {
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
}
