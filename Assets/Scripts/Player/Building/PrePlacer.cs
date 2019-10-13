using UnityEngine;

public class PrePlacer : MonoBehaviour
{
	Turret turret;
	StatsPlayer stats;
	public bool canSpawn;
	// Start is called before the first frame update
	void Awake()
	{
		turret = GetComponent<Turret>();
		canSpawn = true;
		stats = GetComponent<StatsPlayer>();
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == gameObject.tag)
		{
			canSpawn = false;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == gameObject.tag)
		{
			canSpawn = true;
		}
	}
	public void Activate()
	{
		turret.enabled = true;
		stats.enabled = true;
	}
}
