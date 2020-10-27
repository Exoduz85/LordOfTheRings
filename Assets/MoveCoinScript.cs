using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoinScript : MonoBehaviour
{
    public float lifeTimer;
    public float lifeTimerMax;
    public Vector3 firstHalfMoveVector;
    public Vector3 secondHalfMoveVector;
    public float movePosMultiplier;
    public float increaseScale;
    public float decreaseScale;
    void Update() {
        this.transform.position += this.firstHalfMoveVector * Time.deltaTime;
        this.firstHalfMoveVector -= this.firstHalfMoveVector * (this.movePosMultiplier * Time.deltaTime);
        if (this.lifeTimer > this.lifeTimerMax * .5f) {
            this.transform.localScale += Vector3.one * (this.increaseScale * Time.deltaTime);
        }
        else {
            this.firstHalfMoveVector = this.secondHalfMoveVector;
            this.transform.localScale += Vector3.one * (this.decreaseScale * Time.deltaTime);
        }
        if (lifeTimer <= 0) {
            Destroy(this.gameObject);
        }
        this.lifeTimer -= Time.deltaTime;
    }
    
}