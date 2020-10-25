using System;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour {
    public float attackTime = 0.6f;
    public float damage = 5f;
    public float health = 100f;
    public float maxHealth = 100f;
    public Text floatingDamageText;
    public HealthBarScript healthBar;
    float elapsedTime;

    GameObject Target => GetComponent<Target>().value;
    bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().Exists;
    bool CanAttack => !this.IsChargingAttack && this.HasTarget;
    bool IsChargingAttack => this.elapsedTime < this.attackTime;
    bool IsDead => this.health <= 0f;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update() {
        UpdateTime();
        if (this.CanAttack) {
            Attack();
        }
    }

    void UpdateTime() {
        this.elapsedTime += Time.deltaTime;
    }

    void Attack() {
        var unit = this.Target.GetComponent<Unit>();
        unit.TakeDamage(this.damage);
        InstanciateDamagePopUpText();
        Debug.Log($"{this} attacks {this.Target} for {this.damage} damage!", this);
        this.elapsedTime -= this.attackTime;
    }

    public void TakeDamage(float damage) {
        this.health -= damage;
        healthBar.SetHealth(health);
        if (this.IsDead) {
            Destroy(this.gameObject);
        }
    }

    void InstanciateDamagePopUpText()
    {
        var damageTextInstance = Instantiate(floatingDamageText, this.Target.transform.position, Quaternion.identity);
        damageTextInstance.transform.SetParent(this.transform);
    }
}