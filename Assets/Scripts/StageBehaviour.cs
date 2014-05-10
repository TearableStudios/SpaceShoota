using UnityEngine;
using System.Collections;

public class StageBehaviour : MonoBehaviour {
	
	//The point at which we snap the stage back so it looks continuous, and the points to which it returns
	private Vector3 resetPoint, basePoint;
	
	//The object containing all obstacles, so we don't snap them back too
	private Transform obstacles;
	
	private bool isPaused = false;

	public float speed = 10;
	
	// Use this for initialization
	void Start () {
		//Store the values of the reset and base points for panning
		basePoint = transform.FindChild("StageTop").position;
		resetPoint = transform.FindChild("StageBot").position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isPaused){
			MoveStage();
		}
	}
	
	//Pauses the game
	public void Pause(){
		if(!isPaused){
			isPaused = true;
		}
	}
	//Resumes the game
	public void Resume(){
		if(isPaused){
			isPaused = false;
		}
	}
	
	//Pan the stage according the wanted speed.
	private void MoveStage(){
		transform.Translate(Vector3.down*speed*Time.deltaTime);
		if(transform.position.y < resetPoint.y){
			transform.position = basePoint;
		}
	}
}
