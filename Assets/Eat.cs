using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Eat : MonoBehaviour {
	private int score = 1;
	// Use this for initialization
	void Start () {

	}
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
			GameManager.gm.targetHit(score);
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
