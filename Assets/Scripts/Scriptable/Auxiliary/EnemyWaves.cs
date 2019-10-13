using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Wave",menuName ="Create EnemyWave")]
public class EnemyWaves : ScriptableObject
{
	
	public int Number_enemies;
	public float TimeBetweenSpawn;
	public GameObject enemies;
	
}
