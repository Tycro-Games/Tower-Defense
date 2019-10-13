using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[HideInInspector]
public class Turret : MonoBehaviour
{

	public int Damage = 5;
	public float TimeBetweenAtacks = 1f;
	private float PreviosTimeBetweenAtacks;
	public float Speed_Rotations = 1f;
	private Transform target;
	[Header("Particles")]
	
	public GameObject Muzzle_Flash;
	public Transform pos_Muzzle;
	public GameObject connonBall;
	public Transform CannonBalltransform;

	[Header("Upgrades")]
	Upgrades[] upgrades;
	[SerializeField] public bool Slow;
	private NavMeshObstacle Obstacle;
	public List<EnemyAI> enemies = new List<EnemyAI>();
	private void Start()
	{
		PreviosTimeBetweenAtacks = TimeBetweenAtacks;
		upgrades = GetComponents<Upgrades>();


		Obstacle = GetComponent<NavMeshObstacle>();
		Obstacle.enabled = true;

		//check if upgrades are disabled

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{

			EnemyAI enemy = other.GetComponent<EnemyAI>();

			if (!enemies.Contains(other.GetComponent<EnemyAI>()))
			{
				enemies.Add(other.GetComponent<EnemyAI>());
				if (target == null)
				{

					target = enemy.transform;

				}

			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Enemy")
		{
			if (enemies.Contains(other.GetComponent<EnemyAI>()))
			{
				if (target == other.GetComponent<EnemyAI>().transform)
				{
					EnemyAI enemy = other.GetComponent<EnemyAI>();
					target = null;

				}
				enemies.Remove(other.GetComponent<EnemyAI>());
			}
		}
	}
	private void Update()
	{

		TimeBetweenAtacks -= Time.deltaTime;
		foreach (EnemyAI AI in enemies)
		{
			FindTarget(AI);

		}
		if (target != null)
		{
			Rotate(target.position);
		}
	}
	void FindTarget(EnemyAI AI)
	{
		if (AI != null && target == null)
		{
			target = AI.transform;
		}
		if (AI != null && TimeBetweenAtacks <= 0)
		{
			TimeBetweenAtacks = PreviosTimeBetweenAtacks;
			Shooting(AI);
		}
	}
	void Rotate(Vector3 target)
	{
		Vector3 targetDir = target - transform.position;
		Vector3 rotation = Vector3.RotateTowards(transform.forward, targetDir, Speed_Rotations * Time.deltaTime, 0.0f);
		transform.rotation = new Quaternion(transform.rotation.x, Quaternion.LookRotation(rotation).y, transform.rotation.z, Quaternion.LookRotation(rotation).w);


	}
	public void Shooting(EnemyAI AI)
	{
		RaycastHit hit;


		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{

			if (hit.transform.tag == "Enemy")
			{
				

				GameObject CannonBall = Instantiate(connonBall, CannonBalltransform.position, transform.rotation);


				Destroy(CannonBall, 20f);

			}
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(transform.position, 15);
	}
}
