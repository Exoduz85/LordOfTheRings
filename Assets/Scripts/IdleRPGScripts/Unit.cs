using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour {
    public float attackTime = 0.6f;
    public float damage = 5f;
    public float health = 100f;
    public float maxHealth = 100f;
    public int objectValue;
    public Text floatingDamageText;
    public HealthBarScript healthBar;
    public GameObject goldSpawner;
    float elapsedTime;
    public float t = 0;
    
    public GameObject Target => GetComponent<Target>().value;
    bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().Exists;
    public bool CanAttack => !this.IsChargingAttack && this.HasTarget;
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
        InstantiateDamagePopUpText();
        //Debug.Log($"{this} attacks {this.Target} for {this.damage} damage!", this);
        this.elapsedTime -= this.attackTime;
    }

    public void TakeDamage(float damage) {
        this.health -= damage;
        healthBar.SetHealth(health);
        if (this.IsDead)
        {
            InstantiateGoldSpawner();
            Destroy(this.gameObject);
        }
    }
    void InstantiateDamagePopUpText() {
        var damageTextInstance = Instantiate(floatingDamageText, this.Target.transform.position, Quaternion.identity);
        damageTextInstance.transform.SetParent(this.transform);
    }

    private void InstantiateGoldSpawner()
    {
        var goldSpawner = Instantiate(this.goldSpawner, this.transform.position, Quaternion.identity);
        goldSpawner.GetComponent<GoldSpawner>().objectValue = this.objectValue;
        goldSpawner.transform.SetParent(FindObjectOfType<Hero>().transform);
    }

    void MoveTowards(GameObject target)
    {
        this.transform.Translate(Vector3.Lerp(this.transform.position, target.transform.position, t));
    }
}