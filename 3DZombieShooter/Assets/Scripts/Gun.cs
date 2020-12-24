using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] Transform _shootpoint;
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] float _bulletSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = GameObject.Instantiate(_bullet, _shootpoint.position, _shootpoint.rotation);
        bullet.transform.position = _shootpoint.position;

        bullet.GetComponent<Rigidbody>().velocity = _cameraTransform.forward * _bulletSpeed;
    }
}