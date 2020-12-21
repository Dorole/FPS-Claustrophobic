using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public int ScoreValue = 0;
	public float TimeValue = 0.0f;

	public GameObject TargetExplodeParticleSystemPrefab;

	private void OnCollisionEnter(Collision collision)
	{
		if (GameManager.Instance.IsGameOver)
			return;

		if (!collision.collider.CompareTag("Projectile"))
			return;

		GameManager.Instance.UpdateScore(ScoreValue);
		GameManager.Instance.UpdateTime(TimeValue);

		if (gameObject.tag == "Enemy")
			FindObjectOfType<AudioManager>().Play("Wrong");
		else if (gameObject.tag == "Target")
			FindObjectOfType<AudioManager>().Play("Correct");
		else if (gameObject.tag == "Time")
			FindObjectOfType<AudioManager>().Play("Time");

		if (TargetExplodeParticleSystemPrefab != null)
			Instantiate(TargetExplodeParticleSystemPrefab, transform.position, Quaternion.identity);

		Destroy(collision.gameObject);
		Destroy(gameObject);
	}

}
