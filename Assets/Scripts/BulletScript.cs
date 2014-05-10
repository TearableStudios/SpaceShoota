using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.collider.gameObject.layer == LayerMask.NameToLayer("BulletLimits")){
			gameObject.SetActive(false);
			transform.position = new Vector3(50, 13, 69);
			rigidbody.velocity = Vector3.zero;
		}
	}
}
