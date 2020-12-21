using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private IEnumerator WaitBeforeSceneLoad() 
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Projectile"))
            return;
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(WaitBeforeSceneLoad());
       
    }
}
