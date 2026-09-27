
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [Header("Level Settings")]
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 50;

    [Header("XP Scaling")]
    public float xpMultiplier = 1.5f;

    public void GainXP(int amount)
    {
        currentXP += amount;

        Debug.Log("Nhan XP: " + amount);

        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;

        xpToNextLevel = Mathf.CeilToInt(
            xpToNextLevel * xpMultiplier
        );

        Debug.Log("LEVEL UP! Level: " + level);
        Debug.Log("XP can cho level tiep theo: " + xpToNextLevel);
    }
}