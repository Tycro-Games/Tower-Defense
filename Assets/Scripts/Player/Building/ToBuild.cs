using System.Collections;
using UnityEngine;

public class ToBuild : MonoBehaviour
{

	public GameObject ToPlacer;
	public float Range = 10f;
	GameObject Place;
	Shoot shoot;
	Transform cam;
	RaycastHit pos;
	Vector3 offset;
	bool Placing = false;
	public LayerMask layer;
	
	// Start is called before the first frame update
	private void Start()
	{
		cam = Camera.main.transform;
		shoot = GetComponent<Shoot>();

	}

	// Update is called once per frame
	void Update()
	{
		if (ToPlacer != null && offset == Vector3.zero)
		{
			offset = new Vector3(0, ToPlacer.transform.localScale.y / 2, 0);
		}

		RaycastHit hit;
		if (Physics.Raycast(cam.position, cam.forward, out hit, Range, layer) && ToPlacer != null)
		{
			
			if (Input.GetKeyDown(KeyCode.B) && !Placing)
			{



				Place = Instantiate(ToPlacer, hit.point + offset, transform.rotation);
				Placing = true;



			}
			else if (Input.GetKeyDown(KeyCode.B))
			{
				Placing = false;
				Destroy(Place);
				
				
				shoot.enabled = true;

			}

			if (Placing)
			{

				shoot.enabled = false;
				Place.transform.position = hit.point + offset;
				Place.transform.rotation = transform.rotation;
				
			}
			if (Input.GetMouseButtonDown(0) && Placing && Place.GetComponent<PrePlacer>().canSpawn)
			{
				Placing = false;
				Place.GetComponent<PrePlacer>().Activate();
				InteractionWithGround.Add(Place.GetComponentInChildren<Transform>());
				Place = null;
				shoot.Firerate = shoot.Saved_Firerate;
				shoot.enabled = true;
				
			}
		}
		else if (Placing)
		{
			Placing = false;
			shoot.Firerate = shoot.Saved_Firerate;
			shoot.enabled = true;
			Destroy(Place);
		}

	}
	



}


