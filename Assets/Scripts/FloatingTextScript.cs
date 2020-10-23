using System;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    public float lifeTimer = .5f;
    public float lifeTimerMax = .5f;
    void Update()
    {
        float moveYSpeed = 100f;
        float moveXSpeed = 200f;
        float increaseScale = 1f;
        float decreaseScale = 1f;
        if (lifeTimer > lifeTimerMax * .75f)
        {
            transform.position += new Vector3(moveXSpeed, moveYSpeed) * Time.deltaTime;
            transform.localScale += Vector3.one * (increaseScale * Time.deltaTime);
        }
        else if(lifeTimer > lifeTimerMax * .5f)
        {
            transform.position += new Vector3(-moveXSpeed * 2, moveYSpeed) * Time.deltaTime;
            transform.localScale += Vector3.one * (increaseScale * Time.deltaTime);
        }
        else if (lifeTimer > lifeTimerMax * .25f)
        {
            transform.position += new Vector3(moveXSpeed, moveYSpeed) * Time.deltaTime;
            transform.localScale -= Vector3.one * (decreaseScale * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(-moveXSpeed * 2, moveYSpeed) * Time.deltaTime;
            transform.localScale -= Vector3.one * (decreaseScale * Time.deltaTime);
        }
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        lifeTimer -= Time.deltaTime;
    }
}
