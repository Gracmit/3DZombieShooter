using System;
using System.Net.Sockets;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Gun _gun;

    public void SetGun(Gun gun) => _gun = gun;
    private void OnCollisionEnter(Collision other)
    {
        gameObject.SetActive(false);
        _gun.AddToPool(this);
    }
}