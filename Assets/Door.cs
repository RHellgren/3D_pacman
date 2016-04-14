using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Transform door;
	public bool oneway;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (oneway)
			door.GetComponent<BoxCollider> ().enabled = true;
		if (!oneway)
			door.GetComponent<BoxCollider> ().enabled = false;

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			oneway = true;
		}
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			oneway = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			oneway = false;
		}

}
}