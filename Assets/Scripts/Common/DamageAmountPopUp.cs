using Heroes;
using UnityEngine;
using UnityEngine.UI;

namespace Common{
    public class DamageAmountPopUp : MonoBehaviour
    {
        public float lifeTimer;
        public float lifeTimerMax;
        public Vector3 firstHalfMoveVector;
        public Vector3 secondHalfMoveVector;
        public float movePosMultiplier;
        public float increaseScale;
        public float decreaseScale;
        public float t;

        void Update() {
            LerpDamageUp(GetComponentInParent<Unit>().damage, this.gameObject.GetComponent<Text>());
            transform.position += firstHalfMoveVector * Time.deltaTime;
            firstHalfMoveVector -= firstHalfMoveVector * (movePosMultiplier * Time.deltaTime);
            if (lifeTimer > lifeTimerMax * .5f) {
                transform.localScale += Vector3.one * (increaseScale * Time.deltaTime);
            }
            else {
                firstHalfMoveVector = secondHalfMoveVector;
                transform.localScale += Vector3.one * (decreaseScale * Time.deltaTime);
            }
            if (lifeTimer <= 0) {
                Destroy(gameObject);
            }
            lifeTimer -= Time.deltaTime;
        }
        public void LerpDamageUp(float damage, Text damageText)
        {
            t += Time.deltaTime / lifeTimerMax;
            float valueToLerp = Mathf.Lerp(0, damage, t * .75f);
            damageText.text = valueToLerp.ToString("0");
        }
    }
}