using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public static GameManager gm;
	public int score=0;
	public Text mainScoreDisplay;
	// Use this for initialization
	void Start () {
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void targetHit (int scoreAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();

	}
}
