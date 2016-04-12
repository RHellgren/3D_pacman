using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public Transform otherTeleport;
	public float offset;
	// Use this for initialization
	void Start () {
		
	}
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {

			other.gameObject.transform.position = new Vector3 (otherTeleport.position.x+offset,other.gameObject.transform.position.y,otherTeleport.position.z);
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}

}
