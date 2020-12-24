using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit");
        gameObject.SetActive(false);
    }
    
}