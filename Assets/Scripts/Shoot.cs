using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject BulletPrefab;
	//public GameObject GrenadePrefab;

	public Transform FiringPointTransform;

	public float BulletFiringPower = 50.0f;
	//public float GrenadeFiringPower = 12.5f;

	private GameObject _projectilePrefab;
	private float _firingPower;

	private bool _shouldFire = false;

    private void Update()
	{
		//if (GameManager.Instance.IsGameOver)
		//	return;

		_shouldFire = false;

		if (Input.GetButtonDown("Fire1")) 
		{
			_projectilePrefab = BulletPrefab;
			_firingPower = BulletFiringPower;
			_shouldFire = true;
			FindObjectOfType<AudioManager>().Play("Shoot");
		}
		/*else if (Input.GetButtonDown("Fire2")) 
		{
			_projectilePrefab = GrenadePrefab;
			_firingPower = GrenadeFiringPower;
			_shouldFire = true;
		}*/

		if (_shouldFire) 
		{
		
			if (_projectilePrefab == null)
				return;

			//stvaramo novu instancu bullet prefaba
			GameObject newProjectile = Instantiate(_projectilePrefab, FiringPointTransform.position, Quaternion.identity);

			Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();

			if (projectileRigidbody == null)
				return;

			projectileRigidbody.AddForce(FiringPointTransform.forward * _firingPower, ForceMode.VelocityChange);

		}
		
	
	}

}
