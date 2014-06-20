using UnityEngine;
using System.Collections;


public class PlayerScript : MonoBehaviour {
	
	public enum MoveDir{
		Up,
		Down, 
		Left, 
		Right
	}

	private const int LEFT_MOUSE_BUTTON  = 0;
	private const int RIGHT_MOUSE_BUTTON  = 1;


	public float moveSpeed = 4;
	public float bulletSpeed = 800;

	public GameObject shot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
			Move(MoveDir.Up);
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			Move(MoveDir.Down);
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			Move(MoveDir.Right);
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			Move(MoveDir.Left);
		}

		if(Input.GetMouseButton(LEFT_MOUSE_BUTTON)){
			FireShot();
		}
#elif UNITY_ANDROID || UNITY_IPHONE

#endif

		rigidbody.AddForce(0, 0, 0);
		rigidbody.velocity = Vector3.zero;
	}

	void Move(MoveDir dir){
		switch(dir)
		{
		case MoveDir.Up:
			transform.position += Vector3.up*moveSpeed*Time.deltaTime;
			break;
		case MoveDir.Down:
			transform.position += Vector3.down*moveSpeed*Time.deltaTime;
			break;
		case MoveDir.Right:
			transform.position += Vector3.right*moveSpeed*Time.deltaTime;
			break;
		case MoveDir.Left:
			transform.position += Vector3.left*moveSpeed*Time.deltaTime;
			break;
		}
	}

	void FireShot(){
		shot.rigidbody.velocity = Vector3.zero;
		shot.transform.position = transform.position;
		shot.SetActive(true);
		shot.rigidbody.AddForce(transform.up*bulletSpeed);
	}
}
