using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{
	public float maxDistance = 1000000;
	RaycastHit hit;
	public GameObject decalHitWall;
	public float floatInfrontOfWall;
	public GameObject bloodEffect;
	public LayerMask ignoreLayer;
	private EnemyAi enemy;

	private void Start()
    {
		enemy = GameObject.FindObjectOfType<EnemyAi>();
	}
    void Update()
    {
		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
		{
			if (hit.transform.tag == "Dummie")
			{
				Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(gameObject);
				enemy.TakeDamage(1);
			}
            if (hit.transform.tag == "LevelPart")
            {
                Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
                Destroy(gameObject);
            }
            Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}
}
