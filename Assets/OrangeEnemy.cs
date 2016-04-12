using UnityEngine;
using System.Collections;

public class OrangeEnemy : MonoBehaviour {

	public Transform player;
	Vector3 destination;
	NavMeshAgent agent;
	public Transform idle1,idle2,idle3,idle4,idle5,idle6,idle7,idle8;
	public Vector3[] idles;
	public int mode;
	private int index = 0;
	public bool isActivated = false;
	private bool isEatable = false;
		void Start () {
			agent = GetComponent<NavMeshAgent>();
			destination = agent.destination;
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
		void Update () {
			if (!isActivated)
				return;
			//agent.velocity = new Vector3 (5, 0, 5);
			// Update destination if the target moves one unit
			if (mode == 1) {
				if (Vector3.Distance (destination, player.position) > 1.0f) {
					destination = player.position;
					agent.destination = destination;
				}
			}

			if (mode == 3) {
				destination = idles [index];
				agent.destination = destination;
				if (Vector3.Distance (destination, transform.position) < 1.0f) {
					index++;
					if (index == 8)
						index = 0;
				}
			}
		}
}
