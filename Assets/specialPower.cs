using UnityEngine;
using System.Collections;

public class specialPower : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().superMode = true;
		}
		
	}
}
