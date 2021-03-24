using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image progressBar;
    [SerializeField] private Text levelFinishText;
    void Awake()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
        progressBar.fillAmount = 0f;
    }

    void Update()
    {
        progressBar.fillAmount = ((float)GlobalData.TotalCubeDestroyed) / ((float)GlobalData.TotalCubeCount);
        if (GlobalData.TotalCubeDestroyed == GlobalData.TotalCubeCount)
        {
            levelFinishText.text = "Level Finished!";
            GlobalData.Controllable = false;
        }
    }
}
