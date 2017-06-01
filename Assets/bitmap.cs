using UnityEngine;
using System.Collections;

public class bitmap : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		int[,] bitmap_array = new int[128, 128];
		//	Ray ray = Camera.main.ScreenPointToRay (new Vector2(409,219));
		string bitmap = "";

		for (int i = 0; i < 128; i++) {

			for (int j = 0; j < 128; j++) {
			
				Ray ray = new Ray (new Vector2 (j, i), transform.forward);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

				if (hit.collider) {
					if ( hit.collider.gameObject.name == "sub_obstacle") {
						bitmap_array [j, i] = 1;
					} 

				} else {

					bitmap_array [j, i] = 0;
				}
			//	bitmap += bitmap_array [j, i].ToString ();
			}
		//	bitmap += "\n";

		
		}



		for (int j = 127; j> 0; j--) {

			for (int i = 0; i < 128; i++) {

				bitmap += bitmap_array [i, j].ToString ();
			}
			bitmap += "stops\n";


		}
	//		Debug.Log (bitmap);

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
