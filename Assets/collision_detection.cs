using UnityEngine;
using System.Collections;

public class collision_detection : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}


	void OnTriggerStay2D()
	{
		//bfs.collis = true;
	//	Debug.Log("fuck");
	//	gameObject.transform.parent.GetComponent<bfs>().collis = true;
	}

	void OnTriggerExit2D()
	{
		//bfs.collis = true;
	//	Debug.Log("fuck");
	//	gameObject.transform.parent.GetComponent<bfs>().collis = false;

	}
/*	void OnCollisionStay2D()
	{
		//bfs.collis = true;
	//	Debug.Log("Hi");
		if (gameObject.transform.parent.GetComponent<bfs_new3> ().collis != null) {
			gameObject.transform.parent.GetComponent<bfs_new3>().collis = true;
		}

	}

	void OnCollisionEnter2D()
	{
		//bfs.collis = true;
	//	Debug.Log("Hi");
			if (gameObject.transform.parent.GetComponent<bfs_new3> ().collis != null) {

		gameObject.transform.parent.GetComponent<bfs_new3>().collis = true;
		}

	}
	void OnCollisionExit2D()
	{
		//bfs.collis = true;
		if (gameObject.transform.parent.GetComponent<bfs_new3> ().collis != null) {
			gameObject.transform.parent.GetComponent<bfs_new3>().collis = false;
		}
	

	}
	*/


/*	void OnTriggerEnter2D()
	{
		Debug.Log ("Fuck");
	}*/
	
	// Update is called once per frame
	void Update () {
	}
}
