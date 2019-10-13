using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCheckpoint : MonoBehaviour
{
	public float RangeToRemove;
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy")
		{
			if (Vector3.Distance(transform.position, other.transform.position) < RangeToRemove)
			{
				
				other.gameObject.GetComponent<EnemyAI>().Targets.Remove(transform);
			}
		}
	}
}
