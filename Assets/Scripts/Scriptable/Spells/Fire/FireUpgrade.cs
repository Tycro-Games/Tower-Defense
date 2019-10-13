using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireUpgrade : Upgrades
{
	Turret turret;
	public GameObject FireEffect;
	public int dg;
	public bool Slow;
	private void Awake()
	{
		Sring_name = "FireUpgrade";
	}
	private void OnEnable()
	{

		if (turret == null)
			turret = GetComponent<Turret>();

		Debug.Log("Turret is red");
		Upgrade(turret, dg, Slow);
		turret.Slow = Slow;
	}
	private void OnDisable()
	{
		DeUpgrade(turret, dg, Slow);
	}
	public override void Upgrade(Turret turret, int dg, bool Slow)
	{
		base.Upgrade(turret, dg, Slow);

	}
	public override void DeUpgrade(Turret turret, int dg, bool Slow)
	{
		base.DeUpgrade(turret, dg, Slow);

	}
}
