using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
	[SerializeField]
	float Spreadangle = 0;

	[SerializeField]
	float angle = 0;
	[SerializeField]
	float TimeBetweenProjetile = 0;

	[SerializeField]
	int numberOfProjectiles = 0;


	[SerializeField]
	GameObject projectileObject = null;

	Vector2 startPoint;
	[SerializeField]
	float radius, moveSpeed;

	// Use this for initialization
	void Start()
	{
		radius = 5f;
		moveSpeed = 5f;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			SpawnProjectiles( numberOfProjectiles);

		}
	}

	private void SpawnProjectiles(int numberOfProjectiles)
	{
		StartCoroutine(WaitForShot(numberOfProjectiles));
	}

	IEnumerator WaitForShot(int numberOfProjectiles)
	{
		float angleStep = Spreadangle / numberOfProjectiles;
		angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++)
		{
			float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			yield return new WaitForSeconds(TimeBetweenProjetile);
			var proj = Instantiate(projectileObject, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D>().velocity =
				new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
			angle += angleStep;

		}
	}

}