using System;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    public float lifeTimer = .5f;
    public float lifeTimerMax = .5f;
    public Vector3 moveVector;

    private void Start()
    {
        moveVector = new Vector3(1, 2) * 240f;
    }

    void Update()
    {
        float increaseScale = .75f;
        float decreaseScale = -3f;
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * (3f * Time.deltaTime);
        if (lifeTimer > lifeTimerMax * .5f)
        {
            transform.localScale += Vector3.one * (increaseScale * Time.deltaTime);
        }
        else
        {
            moveVector = new Vector3(-3, 3) * 240f;
            transform.localScale += Vector3.one * (decreaseScale * Time.deltaTime);
        }
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        lifeTimer -= Time.deltaTime;
    }
}
