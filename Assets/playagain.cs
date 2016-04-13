using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class playagain : MonoBehaviour {
	public Button button;
	// Use this for initialization
	void Start () {
	}

	void onClick(){
		Application.LoadLevel("Level1");
	}
	// Update is called once per frame
	void Update () {
		button.onClick.AddListener(onClick);
	}
}
