public static class ScoreSystem
{
    #region Variables

    private static int SaveScore;

    #endregion

    #region Properties

    public static int CurrentScore { get; private set; }

    #endregion

    #region Public methods

    public static void AddScore(int amount)
    {
        CurrentScore += amount;
    }

    public static void Load()
    {
        CurrentScore = SaveScore;
        // CurrentScore = PlayerPrefs.GetInt("CurrentScore");
    }

    public static void Save()
    {
        SaveScore = CurrentScore;
    }

    public static void StartScoreSystem()
    {
        CurrentScore = 0;
    }

    #endregion
}