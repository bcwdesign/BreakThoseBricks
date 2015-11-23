using UnityEngine;
using System.Collections;

public class TouchMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



	}

	void OnGUI(){

		foreach(Touch myTouches in Input.touches){
			Debug.Log(myTouches.fingerId + " Pos:" + myTouches.position.x+""+myTouches.position.y);
	
			int num = myTouches.fingerId;
			GUI.Box (new Rect(0+100+num, 100, 150, 100)," Pos:" + myTouches.position.x+""+myTouches.position.y);
		}
	}
}
