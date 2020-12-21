using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Projectile"))
            return;
        GameManager.Instance.StartLevel();
        FindObjectOfType<AudioManager>().Play("Click");
        Destroy(gameObject);
    }
}
