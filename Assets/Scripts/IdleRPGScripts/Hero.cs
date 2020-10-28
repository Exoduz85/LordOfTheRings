using UnityEngine;

public class Hero : MonoBehaviour {
    bool HasTarget => GetComponent<Target>() != null;
    public HealthBarScript healthBar;
    void Update() {
        if (!this.HasTarget) {
            var enemy = FindObjectOfType<Enemy>();
            if (enemy != null) {
                var target = this.gameObject.AddComponent<Target>();
                target.value = enemy.gameObject;
            }
        }
    }
    public void UpgradeHealth()
    {
        GetComponent<Unit>().health *= 1.1f;
        GetComponent<Unit>().maxHealth *= 1.1f;
        healthBar.slider.maxValue = GetComponent<Unit>().maxHealth;
        healthBar.fill.color = healthBar.gradient.Evaluate(healthBar.slider.normalizedValue);
    }
}

/*
The Hero can upgrade his Attack Damage by 10% for 50 Gold.
Repeatable.
    make playerprefs for hero unit, save health, attack cooldown and upgrades.
    save health and attack cooldown for enemy.
Save the currently attacked enemy (with health and attack cool down)
Save the Hero’s current state (upgrades, attack cool down and health

Hero and Unit attack automatically on Cooldown all the time
The player can also tap the Enemy to perform an attach that deals 3
Damage
Visualize The hero’s and the enemy’s health
Spawn a Floating Text every time the hero or the enemy deals damage - done
Visualize the Gold
Visualize the Hero’s Attack Damage and an Upgrade Button
Visualize the Hero’s Health and MaxHealth and an Upgrade Button
*/