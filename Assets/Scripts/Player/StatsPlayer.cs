using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class StatsPlayer : MonoBehaviour
{
	public int Health;
	FirstPersonController FirstPersonController;
	Rigidbody rg;
	public bool forcePush_bool;
	private void Start()
	{
		rg = GetComponent<Rigidbody>();
		FirstPersonController = GetComponent<FirstPersonController>();
	}
	public void TakeDamage(int dg)
	{
		Health -= dg;
		if (Health <= 0)
		{
			
			Die();
		}
		
	}
	
	public IEnumerator ForcePush(float force,float TimeForStun,Vector3 enemy)
	{
		if (!forcePush_bool)
		{
			yield break;
		}
		FirstPersonController.canMove = false;
		FirstPersonController.m_MoveDir=(enemy * force);
		yield return new WaitForSeconds(TimeForStun);

		FirstPersonController.canMove = true;

	}
	void Die()
	{
		InteractionWithGround.Sort(GetComponentInChildren<Transform>());
		Destroy(gameObject);
	}
}
