using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Tạo một biến Instance để có thể dễ dàng gọi GameManager từ bất kỳ đâu
    public static GameManager Instance;

    // Biến lưu trữ dữ liệu, ví dụ: Tổng số sao thu thập được qua các màn cắt dây
    public int TotalStars = 0;

    void Awake()
    {
        // Kiểm tra xem đã có GameManager nào tồn tại trong game chưa
        if (Instance == null)
        {
            // Nếu chưa có, gán Instance chính là object này
            Instance = this;
            
            // Lệnh quan trọng nhất Lab 2: Không tiêu diệt object này khi chuyển scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Nếu người chơi quay lại MenuScene, một GameManager mới sẽ được tạo ra.
            // Chúng ta phải hủy cái mới này đi để tránh việc có 2 GameManager cùng lúc.
            Destroy(gameObject);
        }
    }
}