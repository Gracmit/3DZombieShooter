using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] Transform _shootpoint;
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] float _bulletSpeed = 5f;
    
    Queue<Bullet> _pool = new Queue<Bullet>();

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
        var bullet = GetBullet(); 
        bullet.transform.position = _shootpoint.position;
        bullet.transform.rotation = _shootpoint.rotation;

        bullet.GetComponent<Rigidbody>().velocity = _cameraTransform.forward * _bulletSpeed;
    }

    private Bullet GetBullet()
    {
        Debug.Log(_pool.Count);
        if (_pool.Count > 0)
        {
            var usedBullet = _pool.Dequeue();
            usedBullet.gameObject.SetActive(true);
            return usedBullet;
        }

        var bullet = Instantiate(_bullet, _shootpoint.position, _shootpoint.rotation);
        bullet.SetGun(this);
        return bullet;
    }

    public void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
}