using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class filterController : MonoBehaviour {
	private PlayerController controller;
	// Use this for initialization
	void Start () {
		controller = transform.parent.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.superMode) {
			GetComponent<VignetteAndChromaticAberration>().enabled = true;
		}
		else if (controller.superMode==false)GetComponent<VignetteAndChromaticAberration>().enabled = false;
	}
}
