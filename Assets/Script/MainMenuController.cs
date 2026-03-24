using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có để load scene

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // 1. Gán dữ liệu vào biến static TRƯỚC KHI chuyển scene
        // Giả sử người chơi chọn màn chơi số 5
        DataManager.SelectedLevel = 5; 

        // 2. Load sang GameScene
        SceneManager.LoadScene("GameScene");
    }
}