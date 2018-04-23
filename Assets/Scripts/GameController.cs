using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject gameOverPanel;
	public Text scoreText;
	public Text bestText;
	public Text currText;

	public GameObject newAlert;

	int score = 0;
	// Use this for initialization
	void Start () {
		Debug.Log (scoreText.text);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver() {
		Invoke ("ShowOverPanel", 2.0f);

	}
	void ShowOverPanel() {
		if (score > PlayerPrefs.GetInt ("Best", 0)) {
			PlayerPrefs.SetInt ("Best", score);
			newAlert.SetActive (true);
		}
		bestText.text = "Highscore: " + PlayerPrefs.GetInt ("Best", 0).ToString();
		currText.text = "Current Score: " + score.ToString ();
		scoreText.gameObject.SetActive (false);
		gameOverPanel.SetActive (true);
	}
	public void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void IncrementScore() {
		score++;
		scoreText.text = score.ToString();
	}

}
