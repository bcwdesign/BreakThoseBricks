using UnityEngine;
using System.Collections;

//List of all the possible gamestates
/*public enum GameState
{
	NotStarted,
	Playing,
	Completed,
	Failed
}*/
//Require an audio source for the object
[RequireComponent(typeof(AudioSource))]

public class GameManagerClean : MonoBehaviour {
	
	//Text element to display certain messages on
	//public GUIText FeedbackText;
	
	//Text to be displayed when entering one of the gamestates
	//public string GameNotStartedText;
	//public string GameCompletedText;
	//public string GameFailedText;
	
	//Sounds to be played when entering one of the gamestates
	public AudioClip StartSound;
	public AudioClip FailedSound;
	
	private GameState currentState = GameState.NotStarted;
	//All the blocks found in this level, to keep track of how many are left
	private Brick[] allBricks;
	private Ball[] allBalls;
	private Paddle paddle;
	
	//public GUITexture GuiLevel1;
	public float Timer=0.0f;
	private int minutes;
	private int seconds;
	public string formattedTime;
	public GUIText timeHolder;
	
	// Use this for initialization
	void Start () {
		
		Time.timeScale=1;
		
		//Find all the blocks in this scene
		allBricks = FindObjectsOfType(typeof(Brick)) as Brick[];
		
		//Find all the balls in this scene
		allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];
		
		paddle = GameObject.FindObjectOfType<Paddle>();
		
		print ("Bricks:" + allBricks.Length);
		print ("Balls:" + allBalls.Length);
		print ("Paddle" + paddle);
		
		//Prepare the start of the level
		SwitchState(GameState.NotStarted);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (currentState)
		{
		case GameState.NotStarted:
			//Check if the player taps/clicks.
			if (Input.GetMouseButtonDown(0))    //Note: on mobile this will translate to the first touch/finger so perfectly multiplatform!
			{
				//for (int i = 0; i < allBalls.Length; i++)
				//	allBalls[i].Launch();
				
				SwitchState(GameState.Playing);
			}
			break;
			
		case GameState.Playing:
		{
			Timer += Time.deltaTime;
			minutes= Mathf.FloorToInt(Timer/60F);
			seconds= Mathf.FloorToInt(Timer-minutes *60);
			formattedTime=string.Format("{0:0}:{1:00}", minutes, seconds);
			
			//Display Time
			//print(formattedTime);
			
			//bool allBlocksDestroyed = true;
			bool allBlocksDestroyed = false;
			
			//Check if all blocks have been destroyed
			/*for (int i = 0; i < allBricks.Length; i++)
			{
				if (!allBricks[i].BrickIsDestroyed)
				{
					allBlocksDestroyed = false;
					break;
				}
			}*/
			
			//Are there no balls left?
			if (FindObjectOfType(typeof(Ball)) == null)
				SwitchState(GameState.Failed);
			
			if (allBlocksDestroyed)
				SwitchState(GameState.Completed);
		}
			break;
			//Both cases do the same: restart the game
		case GameState.Failed:
			print ("Gamestate Failed!");
			break;
		case GameState.Completed:
			//bool allBlocksDestroyedFinal = true;
			bool allBlocksDestroyedFinal = false;
			
			//Destroy all the balls
			Ball[] others = FindObjectsOfType(typeof(Ball)) as Ball[];
			
			foreach(Ball other in others) {
				//if (FindObjectOfType(typeof(Ball)) != null)
				Destroy(other.gameObject);
			}
			//Check if all blocks have been destroyed
			/*for (int i = 0; i < allBricks.Length; i++)
			{
				if (!allBricks[i].BrickIsDestroyed)
				{
					allBlocksDestroyedFinal = false;
					break;
				}
			}*/
			
			//Check if the player taps/clicks.
			//if (Input.GetMouseButtonDown(0) && !allBlocksDestroyedFinal)    //Note: on mobile this will translate to the first touch/finger so perfectly multiplatform!
			//   Restart();
			break;
		}
		
	}
	
	public void SwitchState(GameState newState)
	{
		currentState = newState;
		
		switch (currentState)
		{
		default:
		case GameState.NotStarted:
			//DisplayText(GameNotStartedText);
			break;
			
		case GameState.Playing:
			GetComponent<AudioSource>().PlayOneShot(StartSound);
			//DisplayText("");
			//GuiLevel1.enabled = false;
			//GuiLevel1.GetComponent<ParticleSystem>().enableEmission=false;
			break;
			
		case GameState.Completed:
			GetComponent<AudioSource>().PlayOneShot(StartSound);
			//DisplayText(GameCompletedText);
			break;
			
		case GameState.Failed:
			GetComponent<AudioSource>().PlayOneShot(FailedSound);
			//DisplayText(GameFailedText);
			break;
		}
	}
	
	//Helper to display some text
	/*private void DisplayText(string text)
	{
		FeedbackText.text = text;
	}*/
	
}

