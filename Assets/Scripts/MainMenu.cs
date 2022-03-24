using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject storeDisplay;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        if (PlayerPrefs.GetInt(Store.NewColorUnlockedKey, 0) == 1)
        {
            mainCamera.backgroundColor = Color.red;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenStore()
    {
        storeDisplay.SetActive(true);
    }

    public void CloseStore()
    {
        storeDisplay.SetActive(false);
    }
}
