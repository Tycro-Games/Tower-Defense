using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MapGenerator : MonoBehaviour
{
	public int horizontal;
	public int vertical;
	static int x;
	static int y;
	public int Reps;
	[Range(50, 100)]
	public int XMinusProbability;
	private Vector3 step;
	GameObject[,] block;
	GameObject[,] blockRes;
	public GameObject SetPoint;
	public GameObject[] Walls;
	void SetXY()
	{
		x = horizontal;
		y = vertical;
		CreateArray();
	}
	int Multiplier = 10;
	void CreateArray()
	{
		block = new GameObject[x, y];
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + new Vector3(horizontal, 0, vertical) * 10);
	}
	private void Awake()
	{
		Generate();
	}
	public void Create()
	{
		SetXY();
		for (int i = 0; i < x; i++)
		{
			for (int j = 0; j < y; j++)
			{
				GameObject Wall = Walls[Random.Range(0, Walls.Length)];
				Multiplier = Mathf.RoundToInt(Wall.transform.localScale.x);
				int Up = j * Multiplier;
				int Right = i * Multiplier;
				step = new Vector3(Right + transform.position.x, Wall.transform.localScale.y / 2 + GetComponentInParent<Transform>().position.y, Up + transform.position.z);
				block[i, j] = Instantiate(Wall, step, transform.rotation);
				block[i, j].transform.parent = transform;
			}
		}
	}
	public void Generate()
	{
		Create();
		//Spawn in Waves
		while (Reps > 0)
		{
			#region random
			int right = 0;
			int up = Random.Range(1, y - 1);
			#endregion
			Destroy(block[right, up]); //destory first block
			

			while (right + 1 < x) //till we reach the other edge
			{

				if (right == 0)
				{
					right++;
					Destroy(block[right, up]);
				}
				else
				{
					if (Random.Range(0, 2) != 0) //up you go
					{
						//Should we add or decrease?
						if (Random.Range(0, 2) == 0 && up + 1 < y - 1)
						{
							up++;

						}
						else if (up - 1 > 0)
						{
							up--;

						}
					}
					else //then go right
					{
						right++;
					}
					
					Destroy(block[right, up]);

				}

			}

			Vector3 pos = block[right, up].transform.position;
			pos.y = 0;
			Instantiate(SetPoint, pos, Quaternion.identity, transform);
			Reps--;
		}
	}
}