using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	private bool enteredScreen;
	private int moveDirection = 1;
	private float moveSpeed;
	private float topBorder;
	private float botBorder;
	private float leftBorder;
	private float rightBorder;
	private uint counter;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!enteredScreen) 
		{
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
			if (transform.position.y <= topBorder) 
				enteredScreen = true;
			return;
		}

		if (counter % 50 == 0) 
		{
			int moveDir = Random.Range(0,4);
			switch (moveDir) 
			{
			case 1:
				rigidbody.velocity = Vector3.up * moveSpeed * Time.deltaTime * 20;
				break;
			case 2:
				rigidbody.velocity = Vector3.down * moveSpeed * Time.deltaTime * 20;
				break;
			case 3:
				rigidbody.velocity = Vector3.left * moveSpeed * Time.deltaTime * 20;
				break;
			case 4:
				rigidbody.velocity = Vector3.right * moveSpeed * Time.deltaTime * 20;
				break;
			default:
				rigidbody.AddForce(0,0,0);
				break;
			}	
		}
		else
		{
			if (transform.position.x >= rightBorder 
			    || transform.position.x <= leftBorder
			    || transform.position.y >= topBorder 
			    || transform.position.y <= botBorder) 
			{
				rigidbody.velocity = rigidbody.velocity * -1;
			}
		}
		counter++;
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.gameObject.layer == LayerMask.NameToLayer("Shot"))
		{
			gameObject.SetActive(false);
			transform.position = new Vector3(0, 10, 0);
			moveDirection = 1;
		}
	}

	void OnEnable()
	{
		GenerateRandomLocation();
	}

	private void GenerateRandomLocation()
	{
		transform.position = new Vector3(Random.Range(-2.0f,2.0f),10,0);
		topBorder = Random.Range(4.0f,5.0f);
		botBorder = Random.Range(2.0f,5.0f);
		leftBorder = Random.Range(-2.0f,-1.0f);
		rightBorder = Random.Range(1.0f,2.0f);

		moveSpeed = 4;
	}

	void OnDisabled()
	{
		enteredScreen = false;
	}
}
