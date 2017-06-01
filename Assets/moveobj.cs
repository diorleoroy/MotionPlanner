using UnityEngine;
using System.Collections;
using UnityEngine.UI;  

public class moveobj : MonoBehaviour
{
	//public static bool leave_plane = false;
	Vector3 screenSpace;
	
	Vector3 offset;
	// Use this for initialization
	void Start ()
	{
		//checkcol ();

		//	RaycastHit hit;
		/*	GetComponent<PolygonCollider2D>().points = new [] { new Vector2(15,4),new Vector2(-3,4),new Vector2(-3,-4),new Vector2(15,-4)
			,new Vector2(7,4),new Vector2(11,4),new Vector2(11,8),new Vector2(7,8)};*/

		/*	GetComponent<PolygonCollider2D>().points = new [] { new Vector2(15,4),new Vector2(15,-4),new Vector2(-3,-4),new Vector2(-3,4)
			,new Vector2(7,4),new Vector2(7,8),new Vector2(11,8),new Vector2(11,4)};*/


	}
	
	
	// Update is called once per frame
	void Update ()
	{
		//checkcol ();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

		/*if (Input.GetMouseButtonDown (1)) {
		Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
		screenSpace = Camera.main.WorldToScreenPoint (transform.parent.position);
		offset = transform.parent.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
			//			gameObject.transform.parent.Rotate (new Vector3 (0f, 0f, 5f));
			//			transform.parent.position = curPosition;
		transform.parent.rotation = Quaternion.Euler (0, 0, curPosition.x);

			//	transform.parent.Rotate (new Vector3 (0f, 0f,5f));

		}
*/


		if (Input.GetMouseButton (1)) {
		
			//	screenSpace = Camera.main.WorldToScreenPoint (transform.parent.position);
			//	offset = transform.parent.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
			

			if (hit.collider) {
				
				//		screenSpace = Camera.main.WorldToScreenPoint (transform.parent.position);
				//	Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

				//	Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
				

			}
	
			//	transform.parent.rotation = Quaternion.Euler (0, 0, Input.mousePosition.x);


	


		}


	}


	void OnMouseDrag ()
	{
	//Debug.Log ((int)gameObject.GetComponent<Collider2D>().bounds.max.x);
//	Debug.Log (Physics2D.OverlapPoint(gameObject.GetComponent<Collider2D>().bounds.max,1));
	GameObject No_path = GameObject.FindWithTag( "No_path" );
	Text No_path_0 = No_path.GetComponent<Text> ();
	No_path_0.enabled = false;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

		Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

		//convert the screen mouse position to world point and adjust with offset

		//轉換屏幕鼠標位置到世界點，以及通過偏移調整

		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

		if (Input.GetKey (KeyCode.LeftShift)) {
			

			//update the position of the object in the world

			//更新物體在世界的位置

			transform.parent.position = curPosition;

			transform.parent.position = new Vector3 (curPosition.x, curPosition.y, 0);
	//	Debug.Log (gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D>().points[0]));
	
		}


		if (Input.GetKey (KeyCode.LeftControl)) {
			transform.parent.rotation = Quaternion.Euler (0, 0, Input.mousePosition.x);

			//	transform.parent.Rotate (new Vector3 (0f, 0f,Input.mousePosition.x*0.1f));
		}


	}


	void OnMouseOver ()
	{
		

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
		if (Input.GetMouseButtonDown (0)) {

			if (hit.collider) {
				screenSpace = Camera.main.WorldToScreenPoint (transform.parent.position);
				offset = transform.parent.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
				//Debug.Log (Input.mousePosition);
			}

		}
		


		//translate the cubes position from the world to Screen Point
		
		//轉換對象位置，從世界點到屏幕座標
		
		//calculate any difference between the cubes world position and the mouses Screen position converted to a worldpoint
		
		//在對象世界座標與鼠標屏幕座標計算任何不同，轉換到世界點上

	}

	bool collider_obstacle = false;
	bool collider_robot = false;

	/*void checkcol ()
	{
	Vector2 scan_point = new Vector2 ();
		int scan_point_num = 0;
		for (int i = 0; i < 128; i++) {

			for (int j = 0; j < 128; j++) {
				Ray ray = new Ray (new Vector2 (i, j), transform.forward);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

				if (hit.collider.gameObject.name == "sub_robot") {
				
					scan_point = new Vector2 (i, j);
					check_col2 (scan_point);
				}
			}

		}
	}



	void check_col2 (Vector2 input_point)
	{
		Ray ray = new Ray (new Vector2 (input_point.x, input_point.y), transform.forward);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
	if (hit.collider && hit.collider.gameObject.name == "sub_obstacle") {
		Debug.Log ("gggg");
		}

	}
	/*

OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse.



OnMouseDrag is called every frame while the mouse is down.

*/
	

}
