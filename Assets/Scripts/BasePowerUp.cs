using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(AudioSource))]
public class BasePowerUp : MonoBehaviour {

	public float DropSpeed = 1; //How fast does it drop?
	public AudioClip Sound; //Sound played when the powerup is picked up
	
	// Use this for initialization
	void Start()
	{
		GetComponent<AudioSource>().playOnAwake = false;
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		//transform.position += new Vector3 (0, -DropSpeed, 1) * Time.deltaTime;
		//print (transform.position);
	}
	
	//Monobehaviour method, notice the IEnumerator which tells unity this is a coroutine
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		//Only interact with the paddle
		if (other.name == "Paddle")
		{
			//Notify the derived powerups that its being picked up
			OnPickup();
			
			//Prevent furthur collisions
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Renderer>().enabled = false;
			
			//Change the sound pitch if a slowdown powerup has been picked up
			GetComponent<AudioSource>().pitch = Time.timeScale;
			
			//Play audio and wait, without the wait the sound would be cutoff by the destroy
			GetComponent<AudioSource>().PlayOneShot(Sound);
			yield return new WaitForSeconds(Sound.length);
		}
	}
	
	//Every powerup which derives from this class should implement this method!
	//Protected means this method is private and only visible to derived classes
	protected virtual void OnPickup()
	{
		
	}

}
