using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
public class EnemyAI : MonoBehaviour
{
	NavMeshAgent agent;

	private List<Transform> Objective = new List<Transform>();
	private bool Atacking = false;
	private float speedMove = 1f;
	private float SlowspeedMove = 1f;
	public List<Transform> Targets = new List<Transform>();
	public GameObject Explosion;
	public float TimeAtack = 2f;
	public Vector3 OffstInAir;
	float slowTime;
	SpawnEffect effectDead;

	// stats
	private int health;

	//Damage
	private int damage;
	public Stats stats;
	#region ToESC
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(transform.position, stats.GetRangeToSee);
		Gizmos.DrawWireSphere(transform.position, stats.GetRangeToAtack);

	}
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" || (other.tag == "Objective"))
		{
			if (other.GetComponent<StatsPlayer>().enabled)
			{
				if (!Targets.Contains(other.transform))
				{
					Targets.Add(other.transform);
					Targets.Remove(Targets[0]);
				}
			}
		}
	}

	List<Transform> ToTransforms(GameObject[] gameObjects)
	{
		List<Transform> transforms = new List<Transform>();
		for (int i = 0; i < gameObjects.Length; i++)
		{
			transforms.Add(gameObjects[i].transform);
		}
		return transforms;
	}
	Transform CheckObjectives()
	{
		Transform Closest = null;
		float close = Mathf.Infinity;

		foreach (Transform tr in Objective)
		{

			if (Vector3.Distance(transform.position, tr.position) < close)
			{
				close = Vector3.Distance(transform.position, tr.position);
				Closest = tr;
			}

		}
		return Closest;

	}
	void Start()
	{

		effectDead = GetComponent<SpawnEffect>();
		Objective = ToTransforms(GameObject.FindGameObjectsWithTag("Points"));
		Targets.Add(CheckObjectives());
		Targets.Add(GameObject.FindGameObjectWithTag("Wall").transform);
		//Stats
		speedMove = stats.GetMove;
		health = stats.GetHealth;
		damage = stats.GetDamage;
		SlowspeedMove = stats.GetSlowMovement;


		agent = GetComponent<NavMeshAgent>();

		agent.stoppingDistance = stats.GetRangeToAtack;
		agent.speed = speedMove;

	}
	public void SetDestination(Vector3 pos)
	{
		agent.SetDestination(pos);
	}
	public IEnumerator Slow(float SlowTime = 4f)
	{
		agent.speed = SlowspeedMove;
		yield return new WaitForSeconds(SlowTime);
		agent.speed = speedMove;


	}
	// Update is called once per frame
	void Update()
	{

		if (slowTime > 0)
		{
			slowTime -= Time.deltaTime;
		}
		if (Targets.Count != 0)
		{
			if (CheckTargets() != null)
			{
				agent.SetDestination(CheckTargets().position);
			}
			if (CheckTargets().tag != "Points")
			{
				if (!Atacking && CheckTargets().GetComponent<StatsPlayer>() != null)
				{
					Atacking = true;
					StartCoroutine(Atack(CheckTargets()));
				}
			}
		}

	}
	Transform CheckTargets()
	{
		Transform Closest = null;
		float close = Mathf.Infinity;

		foreach (Transform tr in Targets)
		{
			if (tr != null)
			{
				if (Vector3.Distance(transform.position, tr.position) < close)
				{
					close = Vector3.Distance(transform.position, tr.position);
					Closest = tr;
				}
			}
		}
		return Closest;

	}
	IEnumerator Atack(Transform tr)
	{

		yield return new WaitForSeconds(TimeAtack); //time of the animation atack
		StatsPlayer player_stats = null;
		if (tr != null)
		{
			player_stats = tr.GetComponent<StatsPlayer>();
		}
		if (player_stats != null)
		{
			if (Vector3.Distance(transform.position, tr.position) < stats.GetRangeToAtack)
			{
				player_stats.StartCoroutine(player_stats.ForcePush(stats.GetForce, stats.GetstunTime, transform.forward + OffstInAir));
				player_stats.TakeDamage(stats.GetDamage);
			}
		}
		Atacking = false;


	}

	public void TakeDamage(int dg)
	{
		health -= dg;
		if (health <= 0)
		{
			Die();
		}

	}
	public void Die()
	{

		InteractionWithGround.Sort(GetComponentInChildren<Transform>());
		agent.enabled = false;
		GetComponent<CapsuleCollider>().enabled = false;
		enabled = false;
		effectDead.enabled = true;


		Destroy(gameObject, 7f);
	}
	#endregion
}
