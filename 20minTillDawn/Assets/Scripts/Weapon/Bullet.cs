    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float bulletVelocity = 5;
    [SerializeField] private float bulletLifeTime = 1f;

    private void Start()
    {
        StartCoroutine(LifeSpan());
    }
    void Update()
    {
        transform.Translate(Vector3.right * bulletVelocity * Time.deltaTime);
    }

    private IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
