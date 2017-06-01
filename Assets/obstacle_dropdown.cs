using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class obstacle_dropdown : MonoBehaviour {

	List<string> data = new List<string>(){"select obstacle","obstacle0","obstacle1","obstacle2","obstacle3","obstacle4","obstacle5","obstacle6","obstacle7"};
	public Dropdown dropdown;

	public void select_output(int index)
	{
		GameObject[] delete_obstacle = GameObject.FindGameObjectsWithTag ("obstacle");

		Destroy (gameObject.transform.GetComponent<drawobstacle> ());
		//	Destroy (delete_obstacle);
		Debug.Log (delete_obstacle.Length);
		for (int i = 0; i < delete_obstacle.Length; i++) {
			Destroy (delete_obstacle[i]);
		}

		if (index != 0) {
			gameObject.transform.GetComponent<readobstacle> ().read (index-1);
		}

	}

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<readobstacle> (); 
		PopulateList();
	}
	void PopulateList()
	{
		dropdown.AddOptions (data);

	}



}
