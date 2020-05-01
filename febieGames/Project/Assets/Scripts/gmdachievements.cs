using GooglePlayGames;
using UnityEngine;

public class gmdachievements : MonoBehaviour
{
    public void OpenAchievementPanel()
    {
        Social.ShowAchievementsUI();


    }

    public void UpdateIncremental ()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_incremental_achievement, 1, null);
    }

    public void UnlockRegular()
    {
        Social.ReportProgress(GPGSIds.achievement_regular, 100f, null);
    }
}