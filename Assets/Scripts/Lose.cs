using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {
	private Ball ball;
	private GameManager gameManager;
	public GameObject[] players;
	public GameObject[] extras;

	IEnumerator Pause() {
		print("Before Waiting 2 seconds");
		//Switch GameManager State
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.SwitchState (GameState.Failed);
		//gameManager.ChangeText ("You Lose :(");
		//enable the restart and main menu buttons
		gameManager.EnableButtons();

		yield return new WaitForSeconds(2);

		//Find the ball and reset game start
		//ball = GameObject.FindObjectOfType<Ball>();
		//ball.gameStarted = false;

		//Reload level
		//Application.LoadLevel(Application.loadedLevel);

		print("After Waiting 2 Seconds");
	}

	/*void OnTriggerEnter2D (Collider2D trigger){

		extras = GameObject.FindGameObjectsWithTag ("Extra");
		players = GameObject.FindGameObjectsWithTag ("Player");

		if (trigger.gameObject.tag == "Extra") {
			print ("Extra triggered lost");
			Destroy (trigger.gameObject);
			if (extras.Length == 0 && players.Length == 0){
				print ("Lost Triggered - Game Over!");
				
				//Wait before restarting level
				StartCoroutine (Pause ());
			}
		} else if (trigger.name == "Ball") {
			print ("Player trigger");
			if (extras.Length == 0) {
				print ("Lost Triggered - Game Over!");
		
				//Wait before restarting level
				StartCoroutine (Pause ());
			}
		} else {
			print (trigger.name);
		}

		for(int i = 0; i < extras.Length; i++)
		{
			Debug.Log("Extra Count "+i+" is named "+extras[i].name);
		}

		extras = GameObject.FindGameObjectsWithTag ("Extra");
		players = GameObject.FindGameObjectsWithTag ("Player");

		if (extras.Length == 0 && (trigger.name == "Ball" || players.Length == 0)) {
			//	print ("Still more balls left");
			//} else {
			print ("Lost Triggered!");

			//Wait before restarting level
			StartCoroutine (Pause ());
		} else {
			for(int i = 0; i < players.Length; i++)
			{
				Debug.Log("Player Count "+i+" is named "+players[i].name);
			}

			for(int i = 0; i < extras.Length; i++)
			{
				Debug.Log("Extra Count "+i+" is named "+extras[i].name);
			}
		}
	}*/
	void OnTriggerEnter2D (Collider2D trigger){
		if (trigger.name == "Ball") {
			print ("Lost Triggered!");
			
			//Wait before restarting level
			StartCoroutine (Pause ());
		}
	}

}
