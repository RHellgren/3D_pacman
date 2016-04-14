using UnityEngine;
using System.Collections;

public class gameOverText : MonoBehaviour {

	public GameObject gameManager;
	public GameManager manager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("Game Manager");
		manager = gameManager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
