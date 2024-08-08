using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AchievementSystem : MonoBehaviour
{
    // Singleton instance
    private static AchievementSystem instance;

    // Define a dictionary to store the achievements and their unlock status
    private Dictionary<string, bool> achievements = new Dictionary<string, bool>();

    // List of text objects to display achievement states
    public List<TextMeshProUGUI> achievementTexts;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this
            instance = this;
        }
        else
        {
            // If an instance already exists, destroy this instance
            Destroy(gameObject);
            return;
        }

        InitializeAchievements();
        LoadAchievements();
        UpdateAchievementTexts();
    }

    // Function to get the singleton instance
    public static AchievementSystem GetInstance()
    {
        return instance;
    }

    // Function to initialize the achievements
    private void InitializeAchievements()
    {
        achievements.Add("Score 300", false);
        achievements.Add("Score 600", false);
        achievements.Add("Fall 5 times", false);
        achievements.Add("Get 5 bonks", false);
        achievements.Add("Follow my itch", false);
        achievements.Add("Beat the game", false);
    }

    // Function to unlock an achievement
    public void UnlockAchievement(string achievement)
    {
        achievements[achievement] = true;
        SaveAchievements();
        if(Quản_lý.instance != null)
        {
            StartCoroutine(Quản_lý.instance.AchievementUnlocked(achievement));
        }
    }

    // Function to save the achievements
    private void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.Key, achievement.Value ? 1 : 0);// 1 for true, 0 for false by achievement.Value
        }
        PlayerPrefs.Save();
    }

    // Function to load the achievements
    private void LoadAchievements()
    {
        // Create a separate collection to store the modified achievements
        var modifiedAchievements = new Dictionary<string, bool>();

        foreach (var achievement in achievements)
        {
            int unlockStatus = PlayerPrefs.GetInt(achievement.Key, 0);
            modifiedAchievements[achievement.Key] = unlockStatus == 1;
        }

        // Replace the original achievements dictionary with the modified one
        achievements = modifiedAchievements;
    }

    public void UpdateAchievementTexts()
    {
        foreach (TextMeshProUGUI text in achievementTexts)
        {
            string achievementName = text.text;
            bool unlocked = achievements.ContainsKey(achievementName) && achievements[achievementName];
            if (unlocked)
            {
                text.text = "Unlocked";
            }
        }
    }
}
