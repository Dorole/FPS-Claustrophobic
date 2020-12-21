using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Projectile")
			return;
		FindObjectOfType<AudioManager>().Play("Click");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
