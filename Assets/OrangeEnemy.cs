using UnityEngine;
using System.Collections;

public class OrangeEnemy : MonoBehaviour {


	public Transform player;
	Vector3 destination;
	NavMeshAgent agent;
	public Transform idle1,idle2,idle3,idle4;
	public Vector3[] idles;
	public int mode = 1;
	private int index = 0;

		void Start () {

		agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;
			// Cache agent component and destination
		idles = new Vector3[4];
		idles [0] = new Vector3(idle1.position.x,0,idle1.position.z);
		idles [1] = new Vector3(idle2.position.x,0,idle2.position.z);
		idles [2] = new Vector3(idle3.position.x,0,idle3.position.z);
		idles [3] = new Vector3(idle4.position.x,0,idle4.position.z);

		}
		
		void Update () {
		//agent.velocity = new Vector3 (5, 0, 5);
		// Update destination if the target moves one unit
		if (mode == 1) {
			if (Vector3.Distance (destination, player.position) > 1.0f) {
				destination = player.position;
				agent.destination = destination;
			}
		}
			
		if (mode == 2) {
			destination = idles [index];
			agent.destination = destination;
			if (Vector3.Distance (destination, transform.position) < 1.0f) {
				index++;
				if (index == 4)
					index = 0;
			}
		}
	}
}
