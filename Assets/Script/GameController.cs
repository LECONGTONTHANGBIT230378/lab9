using UnityEngine;

public class GameController : MonoBehaviour
{
    // LAB 5: Khai báo biến để kéo thả file GameConfig vào
    public GameConfig currentConfig;

    int currentScore = 0; // Điểm hiện tại của ván chơi
    int highScore = 0;    // Điểm kỷ lục

    void Start()
    {
        // --- LAB 5: ĐỌC DỮ LIỆU TỪ SCRIPTABLE OBJECT ---
        if (currentConfig != null)
        {
            Debug.Log("Đã tải cấu hình game thành công!");
            Debug.Log("Tốc độ người chơi mặc định: " + currentConfig.playerSpeed);
            Debug.Log("Điểm cần đạt để thắng màn này: " + currentConfig.targetScoreToWin);
        }
        else
        {
            Debug.LogWarning("Bạn chưa kéo file GameConfig vào Inspector của GameController!");
        }
        // -----------------------------------------------

        // LAB 1: Lấy giá trị level từ DataManager (nếu bạn vẫn giữ code cũ)
        int levelToLoad = DataManager.SelectedLevel;
        Debug.Log("Đang chơi Level: " + levelToLoad);

        // LAB 3 - ĐỌC DỮ LIỆU: Lấy HighScore đã lưu từ ổ cứng lên
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        Debug.Log("Điểm kỷ lục hiện tại là: " + highScore);
    }

    void Update()
    {
        // GIẢ LẬP GHI ĐIỂM: Mỗi lần nhấn phím Space, người chơi được cộng 10 điểm
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentScore += 10;
            Debug.Log("Điểm hiện tại: " + currentScore);

            // --- ỨNG DỤNG LAB 5: Kiểm tra chiến thắng dựa trên thông số của Config ---
            if (currentConfig != null && currentScore >= currentConfig.targetScoreToWin)
            {
                Debug.Log("Tuyệt vời! Bạn đã đủ điểm qua màn!");
                // Tại đây bạn có thể gọi hàm chuyển sang màn chơi tiếp theo
            }
            // --------------------------------------------------------------------------

            // Kiểm tra xem điểm hiện tại có vượt qua điểm kỷ lục không
            if (currentScore > highScore)
            {
                highScore = currentScore;
                
                // LAB 3 - LƯU DỮ LIỆU: Lưu kỷ lục mới xuống ổ cứng
                PlayerPrefs.SetInt("HighScore", highScore);
                
                // Bắt buộc gọi lệnh Save() để đảm bảo dữ liệu được ghi lại ngay lập tức
                PlayerPrefs.Save(); 
                
                Debug.Log("Chúc mừng! Đã thiết lập kỷ lục mới: " + highScore);
            }
        }

        // TÍNH NĂNG MỞ RỘNG: Nhấn phím R để xóa kỷ lục (Reset Data)
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighScore");
            Debug.Log("Đã xóa kỷ lục về 0!");
        }
    }
}