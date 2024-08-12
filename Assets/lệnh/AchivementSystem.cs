using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AchievementSystem : MonoBehaviour
{
    // Define a dictionary to store the achievements and their unlock status
    private Dictionary<string, bool> achievements = new Dictionary<string, bool>();

    // List of text objects to display achievement states
    public List<TextMeshProUGUI> achievementTexts;

    //singleton pattern
    public static AchievementSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeAchievements();
        LoadAchievements();
        UpdateAchievementTexts();
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
        Debug.Log("Achievement unlocked: " + achievement);
    }

    // Function to save the achievements
    private void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.Key, achievement.Value ? 1 : 0);
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

    public void OpenItch()
    {
        Application.OpenURL("https://hoangson1908.itch.io/");
        UnlockAchievement("Follow my itch");
        UpdateAchievementTexts();
        TrailSystem.instance.OpenTrail();
    }

    public int GetAchievementCount()
    {
        int count = 0;
        foreach (var achievement in achievements)
        {
            if (achievement.Value)
            {
                count++;
            }
        }
        return count;
    }
}
