using UnityEngine;
using System.Collections;


//Make sure there is always an AudioSource component on the GameObject where this script is added.
[RequireComponent(typeof(AudioSource))]
public class Brick : MonoBehaviour {

	public int maxHits;
	public int timesHit;
	private bool BrickIsDestroyed=false;

	//Make the AudioClip and Pitch configurable in the editor
	public AudioClip Sound;
	public float PitchStep = 0.05F;
	public float MaxPitch = 1.3F;

	//Make the current pitch value global, which means it is shared across all instances of the PlaySoundOnHit_Pitch classes
	public static float pitch = 1;

	//Falling variables
	public bool FallDown = false;
	
	[HideInInspector]   //Do not let the user see this value but it does needs to be accesible from other scripts
	public bool BlockIsDestroyed = false;
	
	private Vector2 velocity = Vector2.zero;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (FallDown && velocity != Vector2.zero)
		{
			//Multiplying the velocity with Time.deltaTime before adding it to the current position makes sure
			//the motion is framerate independent
			Vector2 pos = (Vector2)transform.position; 
			pos += velocity * Time.deltaTime;
		}
	}

	void OnBecameInvisible()
	{
		BlockIsDestroyed = true;
		Destroy(gameObject);
	}

	private IEnumerator OnCollisionExit2D(Collision2D c)
	{
		print ("Play Woggle!");
		GetComponent<Collider2D>().enabled = false;
		
		//Play the Woggle animation
		GetComponent<Animation>().Play();
		
		
		//Wait here for the length of the Woggle animation 
		yield return new WaitForSeconds(GetComponent<Animation>()["Woggle"].length);
		//yield return new WaitForSeconds(GetComponent<Animation>()["Scaling"].length);
		
		//Animation Woggle has finished, now decide what to do, falldown or just disappear
		if (FallDown)
		{
			print ("Falling!");
			//Falldown to the direction the ball hit it, with a random speed and plus a little downwards "gravity"
			//velocity = (c.relativeVelocity * Random.Range(1, 2.0F)) + new Vector2(-30, 0);
			velocity = new Vector2(0, Random.Range(1, 12.0F) *-1);
		}
		else
		{
			GetComponent<Renderer>().enabled = false;
		}
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		print ("Ouch you hit me!");
		timesHit++;

		print ("Playing brick sound!");
		//Increase pitch
		pitch += PitchStep;
		
		//Limit pitch
		if (pitch > MaxPitch)
			pitch = 1;  //Reset pitch to one so it starts over with the lower tone
		
		//Apply pitch
		GetComponent<AudioSource>().pitch = pitch;
		
		//Play it once for this collision hit
		GetComponent<AudioSource>().PlayOneShot(Sound);

		if (timesHit == maxHits) {
			print ("Destroyed!");
			//BrickIsDestroyed=true;
			//Destroy(gameObject);

		}
	}

}
