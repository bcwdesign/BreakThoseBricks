using UnityEngine;

//Make sure there is always an AudioSource component on the GameObject where this script is added.
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
	//Make the AudioClip and Pitch configurable in the editor
	public AudioClip Sound;
	public float PitchStep = 0.05F;
	public float MaxPitch = 1.3F;
	
	//Make the current pitch value global, which means it is shared across all instances of the PlaySoundOnHit_Pitch classes
	public static float pitch = 1;
	
	//OnCollisionEnter will only be called when the other collider has a rigidbody, like our ball has
	void OnCollisionEnter2D(Collision2D c)
	{
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
	}
}

