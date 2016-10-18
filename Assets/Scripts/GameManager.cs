using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public enum GameState{
		Playing, Ended
	}

	private static GameManager _instance;
	public static float deathHeight;

	GameObject loseGameGraphics;

	public static GameState State = GameState.Playing;

	public static float timeStarted;
	private static int points;

	void Awake(){
		State = GameState.Playing;
		deathHeight = gameObject.transform.localPosition.y;
		_instance = this;
		_instance.loseGameGraphics = GameObject.Find ("/Canvas/LoseGraphics");
		if (_instance.loseGameGraphics != null)
			_instance.loseGameGraphics.SetActive(false);
	}

	void Start(){
		_instance.setPoints ();
	}

	public void setPoints(){
		if (GameObject.Find ("/Canvas/coinsText"))
			GameObject.Find ("/Canvas/coinsText").GetComponent<Text>().text = points.ToString();
	}

	public static void AddPoints(){
		points += 1;
		_instance.setPoints ();
	}

	public void LoseTheGame(){
		State = GameState.Ended;
		_instance.loseGameGraphics.SetActive(true);
	}

	public static int getPoints(){
		return points;
	}

	public void startTimer(){
		timeStarted = Time.time;
	}
		
}
