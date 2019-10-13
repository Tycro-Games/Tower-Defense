using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ConnonBall : MonoBehaviour
{
	
	public int MinDG = 5;
	public int MaxDG = 10;
	public GameObject HitEffect_Enemy;
	public GameObject HitEffect_Stone;
	private ParticleSystem part;
	public bool Slow;
	public List<ParticleCollisionEvent> collisionEvents;

	private void Start()
	{
		


		part = GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	void OnParticleCollision(GameObject other)
	{


		int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

		EnemyAI enemy;
		enemy = other.GetComponent<EnemyAI>();
		int i = 0;

		while (i < numCollisionEvents)
		{

			if (other.tag == "Enemy")
			{

				GameObject enemyEffect = Instantiate(HitEffect_Enemy, collisionEvents[i].intersection, Quaternion.LookRotation(collisionEvents[i].normal));
				enemyEffect.transform.SetParent(other.transform);
				



				enemy.TakeDamage(Random.Range(MinDG, MaxDG));
				if (Slow)
				{
					enemy.StartCoroutine(enemy.Slow());
				}

				Destroy(gameObject);
			}
			else if (other.layer != 2)
			{

				GameObject Stone = Instantiate(HitEffect_Stone, collisionEvents[i].intersection, Quaternion.LookRotation(collisionEvents[i].normal));
				Destroy(Stone, 20f);
			}
			i++;
		}
	}

}
