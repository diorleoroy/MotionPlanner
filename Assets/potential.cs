using UnityEngine;
using System.Collections;

public class potential : MonoBehaviour
{

	// Use this for initialization
	int[,] potential_array = new int[128, 128];
	Vector2[] potential_tmp = new Vector2[16384];
    Vector2[] potential_tmp2 = new Vector2[16384];
	int visit_num = 0;




	public void Init(string plane_name,string point_obj,int[,] potential_control_point)
	{
		GameObject SearchObject = GameObject.Find (point_obj);
		Vector2 Pos = SearchObject.transform.position;

		potential_input (Pos);
		draw_potential (plane_name);

		for (int i = 0; i < 128; i++) {
			for (int j = 0; j < 128; j++) {

				potential_control_point[i,j] = potential_array [i, j];

			}
		}
	}


	void potential_input (Vector2 start_point)
	{
		//初始化
		for (int i = 0; i < 128; i++) {
			for (int j = 0; j < 128; j++) {

				potential_array [i, j] = 254;

			}
		}



		//	Ray ray = Camera.main.ScreenPointToRay (new Vector2(409,219));


		Vector2 initialcon_point = new Vector2 ();


		initialcon_point.x = start_point.x;
		initialcon_point.y = start_point.y;

		potential_array [(int)initialcon_point.x, (int)initialcon_point.y] = 0;
		//跑起點位置
		visit_neighbor (initialcon_point, 0);


		for (int i = 1; i < 254; i++) {
			int visit_num_tmp = visit_num;
			// potential_tmp 是上一輪拜訪過的點

			for (int j = 0; j < visit_num_tmp; j++) {
				potential_tmp2 [j] = potential_tmp [j];
			}

			//直接用等於會傳位值

			visit_num = 0;
			for (int k = 0; k < visit_num_tmp; k++) {
				visit_neighbor (potential_tmp2 [k], i);
			}

		}

	}

	void visit_neighbor (Vector2 visit_input_point, int potential_value)
	{
		
		Vector2 tmp_point = new Vector2 ();
		potential_value = potential_value + 1;

		tmp_point.x = visit_input_point.x + 1;
		tmp_point.y = visit_input_point.y;
		if (tmp_point.x >= 0 && tmp_point.y >= 0 && tmp_point.y < 128 && tmp_point.x < 128) {
			check_point (tmp_point, potential_value);
		}

		tmp_point.x = visit_input_point.x - 1;
		tmp_point.y = visit_input_point.y;
		if (tmp_point.x >= 0 && tmp_point.y >= 0 && tmp_point.y < 128 && tmp_point.x < 128) {
			check_point (tmp_point, potential_value);
		}

		tmp_point.x = visit_input_point.x;
		tmp_point.y = visit_input_point.y + 1;
		if (tmp_point.x >= 0 && tmp_point.y >= 0 && tmp_point.y < 128 && tmp_point.x < 128) {
			check_point (tmp_point, potential_value);
		}

		tmp_point.x = visit_input_point.x;
		tmp_point.y = visit_input_point.y - 1;
		if (tmp_point.x >= 0 && tmp_point.y >= 0 && tmp_point.y < 128 && tmp_point.x < 128) {
			check_point (tmp_point, potential_value);
		}

	

	}


	void check_point (Vector2 input_point, int check_potential_value)
	{
		Ray ray = new Ray (new Vector2 (input_point.x, input_point.y), transform.forward);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);


		if (potential_array [(int)input_point.x, (int)input_point.y] == 254 && input_point.x <= 127 && input_point.x >= 0 && input_point.y >= 0 && input_point.y <= 127) {
			
			if (hit.collider && hit.collider.gameObject.name == "sub_obstacle") {

				potential_array [(int)input_point.x, (int)input_point.y ] = 255;
					
			} else {
				potential_array [(int)input_point.x, (int)input_point.y] = check_potential_value;
				potential_tmp [visit_num] = input_point;
				visit_num++;
			}
				
		}
			
		
	}





	void draw_potential (string plane_name_0)
	{

		GameObject SearchObject = GameObject.Find (plane_name_0);

		Texture2D texture = new Texture2D (128, 128);

		SearchObject.GetComponent<Renderer> ().material.mainTexture = texture;



		for (int y = 127; y >= 0; y--) {
			for (int x = 0; x < 128; x++) {
				//	Color color = ((x & y) != 0 ? Color.white : Color.gray);
				int c = 255 - (byte)potential_array [x, y];
				Color32 color = new Color32 ((byte)c, (byte)c, (byte)c, 125);
				//	Color32 color = new Color32((byte)potential_array[x,y], (byte)potential_array[x,y], (byte)potential_array[x,y], 255);
				//	Color32 color = new Color32(0,0,0, 255);
				//	Debug.Log (c);
				texture.SetPixel (x, y, color);
			}
		}
			
		texture.Apply ();
		SearchObject.transform.rotation = Quaternion.Euler (90, 90, -90);
	}
		
	// Update is called once per frame
	void Update ()
	{
	
	}
}

