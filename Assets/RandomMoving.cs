using UnityEngine;
using System.Collections;

public class RandomMoving : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.MovePosition(transform.position+1);
	}
}
