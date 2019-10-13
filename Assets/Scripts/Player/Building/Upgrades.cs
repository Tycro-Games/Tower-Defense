using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
	public string Sring_name;


	public virtual void Upgrade(Turret turret,int dg,bool Slow)
	{
		turret.Damage+=dg;
		
	}
	public virtual void DeUpgrade(Turret turret, int dg, bool Slow)
	{
		turret.Damage -= dg;
	}
}
