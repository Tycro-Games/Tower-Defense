using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
	public Vector3 pos;
	public EnemyWaves[] waves;
	bool isWaving = false;
	public float Minx;
	public float Maxx;
	public float Minz;
	public float Maxz;
	public InteractionWithGround interactionWithGround;
	private void OnDrawGizmos()
	{
		

		Gizmos.color = Color.red;
		Gizmos.DrawLine(new Vector3(Minx, 0, Minz) + pos, new Vector3(Maxx, 0, Maxz)+pos);

	}
	private IEnumerator Start()
	{
		pos = transform.position;
		foreach (EnemyWaves wave in waves)
		{
			Debug.Log("Wave: " + wave.name);

			StartCoroutine(SpawnEnemy(wave.Number_enemies, wave.enemies, wave.TimeBetweenSpawn));

			yield return new WaitUntil(() => !isWaving);
		}

	}
	public IEnumerator SpawnEnemy(int count, GameObject enemy, float TimeBetweenEnemies)
	{
		isWaving = true;
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(TimeBetweenEnemies);

			GameObject en=Instantiate(enemy, new Vector3(Random.Range(Minx, Maxx), pos.y, Random.Range(Minz, Maxz)), Quaternion.identity,transform);
			InteractionWithGround.Add(en.GetComponentInChildren<Transform>());
		}
		isWaving = false;

	}
}
