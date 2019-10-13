using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	public int Health = 10;
	public float RangeToExplode=5f;
	public void TakeDamage(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Die();
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy" )
		{
			if (Vector3.Distance(transform.position, other.transform.position)<RangeToExplode)
			{
				TakeDamage(other.GetComponent<EnemyAI>().stats.GetDamageOnWall);
				other.gameObject.GetComponent<EnemyAI>().Die();
			}
		}
	}
	private void Die()
	{
		Debug.Log("You lose");
	}
}
