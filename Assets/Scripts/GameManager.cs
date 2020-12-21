using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int Score = 0;
	public Text ScoreText;
	public int ScoreGoalForNextLevel = 50;

	public float StartTime = 20.0f;
	public Text TimerText;

	public GameObject RestartLevel;
	public GameObject NextLevel;
	public GameObject GameplayCanvas;

	[SerializeField] private float _timer = 0.0f;

	private bool _isGameOver = false;

	//property
	public bool IsGameOver => _isGameOver;

	private void Awake()
	{
		//singleton
		Instance = this;

		UpdateScore(0);
		_timer = StartTime;

		NextLevel.SetActive(false);
		RestartLevel.SetActive(false);
		GameplayCanvas.SetActive(true);

		_isGameOver = true;

	}

	public void Update()
	{

		if (_isGameOver)
			return;
		
		UpdateTime(-Time.deltaTime);

		if (_timer <= 0.0f)
		{
			Debug.Log("Game over");
			_timer = 0.0f;
			_isGameOver = true;
			RestartLevel.SetActive(true);
		}
	}

	public void UpdateScore(int value)
	{
		Score += value;
		ScoreText.text = Score.ToString();

		if (Score >= ScoreGoalForNextLevel)
		{
			_isGameOver = true;
			NextLevel.SetActive(true);			
		}
	}

	public void UpdateTime(float value)
	{
		_timer += value;
		TimerText.text = _timer.ToString("F1");
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);

	}

	public void BackToMenu()
    {
		SceneManager.LoadScene(0);
    }

	public void StartLevel()
    {
		_isGameOver = false;
    }

	public void ExitGame()
	{
		Application.Quit();
	}

}
