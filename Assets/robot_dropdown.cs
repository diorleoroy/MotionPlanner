using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class robot_dropdown : MonoBehaviour {

	List<string> data = new List<string>(){"select robot","robot0","robot1","robot2","robot3","robot4","robot5","robot6","robot7"};
	public Dropdown dropdown;

	public void select_output(int index)
	{
		GameObject[] delete_robot = GameObject.FindGameObjectsWithTag ("robot");
		Destroy (gameObject.transform.GetComponent<drawrobot> ());

		for (int i = 0; i < delete_robot.Length; i++) {
			Destroy (delete_robot[i]);
		}
		if (index != 0) {
			gameObject.transform.GetComponent<readrobot> ().read (index-1);
		}

	}

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<readrobot> (); 
		PopulateList ();
	}
	void PopulateList()
	{
		dropdown.AddOptions (data);

	}



}
