using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("box"))
        {
            GameObject explosion = Instantiate(GameManager.Instance.particleVFXs[Random.Range(0,GameManager.Instance.particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
            Destroy(gameObject);
            GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
        }
        if(other.transform.CompareTag("gr"))
        {
            Destroy(gameObject);
            GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
        }
    }
}
