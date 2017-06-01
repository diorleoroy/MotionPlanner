using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class show_potential : MonoBehaviour
{
	public static int[,] potential_control_point_0 = new int[128, 128];
	public static int[,] potential_control_point_1 = new int[128, 128];
	/*void Start () {  
		List<string> btnsName = new List<string>();  
		btnsName.Add("Button");  

		foreach(string btnName in btnsName)  
		{  
			GameObject btnObj = GameObject.Find(btnName);  
			Button btn = btnObj.GetComponent<Button>();  
			btn.onClick.AddListener(delegate() {  
				this.OnClick(btnObj);   
			});  
		}   
	}  

	public void OnClick(GameObject sender)  
	{  
		switch (sender.name)  
		{  
		case "Button":  
			Debug.Log("Button");  
			break;  
		case "BtnShop":  
			Debug.Log("BtnShop");  
			break;  
		case "BtnLeaderboards":  
			Debug.Log("BtnLeaderboards");  
			break;  
		default:  
			Debug.Log("none");  
			break;  
		}  
	}  */

	void Start ()
	{
		Button btn = gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick ()
	{
		//	string ObjectName = "plane";
		//	GameObject SearchObject = GameObject.Find (ObjectName);



		string plane_name = "potential_0";
		string goal_control_point = "goal_control_point_0";
		gameObject.GetComponent<potential> ().Init (plane_name, goal_control_point, potential_control_point_0);


		plane_name = "potential_1";
		goal_control_point = "goal_control_point_1";
		gameObject.GetComponent<potential> ().Init (plane_name, goal_control_point, potential_control_point_1);
	}

	// Update is called once per frame
	void Update ()
	{  

	}
}
