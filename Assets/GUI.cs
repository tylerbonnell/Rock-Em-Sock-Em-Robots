using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	public static GUI singleton;
	public Text winText;
	public Text playAgain;
	public Text[] controls;

	// Use this for initialization
	void Start () {
		singleton = this;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
	
	public void SetWinText (string winnerName) {
		foreach (Text t in controls)
			t.text = "";
		winText.text = winnerName.ToUpper () + " WINS";
		playAgain.text = "PRESS SPACE TO PLAY AGAIN";
	}
}
