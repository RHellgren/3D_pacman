using UnityEngine;
using System.Collections;

public class specialPower : MonoBehaviour {
	public AudioSource eatCherry;
	private int score = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
			GameManager.gm.targetHit(score);
			eatCherry.Play();
			other.gameObject.GetComponent<PlayerController>().superMode = true;

		}
		
	}
}
