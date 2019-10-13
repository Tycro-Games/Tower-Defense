using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats", order = 51)]

public class Stats : ScriptableObject
{
	//Life
	[SerializeField] private int Health = 0;
	[SerializeField] private float MoveSpeed = 0;
	[SerializeField] private float SlowMovement = 5;

	//Atack


	[SerializeField] private int Damage = 0;
	[SerializeField] private float RangeToSee = 0;
	[SerializeField] private int DamageOnWall = 0;
	[SerializeField] private int RangeToAtack = 0;

	//stun
	[SerializeField] private float stunTime = 0;
	[SerializeField] private float force = 0;
	
	public float GetSlowMovement
	{
		get
		{
			return SlowMovement;
		}
	}
	public float GetstunTime
	{
		get
		{
			return stunTime;
		}
	}
	public float GetForce
	{
		get
		{
			return force;
		}
	}
	public int GetRangeToAtack
	{
		get
		{
			return RangeToAtack;
		}
	}
	public int GetHealth
	{
		get
		{
			return Health;
		}
	}
	public float GetRangeToSee
	{
		get
		{
			return RangeToSee;
		}
	}
	public float GetMove
	{
		get
		{
			return MoveSpeed;
		}
	}
	public int GetDamage
	{
		get
		{
			return Damage;
		}
	}
	public int GetDamageOnWall
	{

		get
		{
			return DamageOnWall;
		}
	}



}
