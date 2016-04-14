using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class playgame : MonoBehaviour {
	public Button button;
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}

	void onClick(){
		Application.LoadLevel("Level1");
	}
	// Update is called once per frame
	void Update () {
		button.onClick.AddListener(onClick);
	}
}
