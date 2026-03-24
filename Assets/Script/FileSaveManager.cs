using UnityEngine;
using System.IO; // BẮT BUỘC: Thư viện này cho phép C# can thiệp vào file và thư mục của máy tính

public class FileSaveManager : MonoBehaviour
{
    // Hiển thị ra Inspector để dễ quan sát
    public PlayerData myData; 
    
    // Biến lưu đường dẫn tới file save
    private string saveFilePath;

    void Start()
    {
        // Khởi tạo dữ liệu mặc định
        myData = new PlayerData();

        // CỰC KỲ QUAN TRỌNG: Xác định vị trí lưu file
        // Application.persistentDataPath sẽ tự động trỏ đến thư mục an toàn nhất trên Win/Mac/Android/iOS
        saveFilePath = Application.persistentDataPath + "/MySaveGame.json";
        
        Debug.Log("Đường dẫn file save của bạn là: " + saveFilePath);
    }

    void Update()
    {
        // Nhấn phím S để LƯU GAME
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGameToFile();
        }

        // Nhấn phím L để ĐỌC GAME
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGameFromFile();
        }
    }

    public void SaveGameToFile()
    {
        // 1. Thay đổi một chút dữ liệu để test
        myData.totalStars = 99;
        myData.candySkin = "Golden_Candy";

        // 2. Ép Object thành chuỗi JSON (Kiến thức Lab 4)
        string jsonString = JsonUtility.ToJson(myData);

        // 3. Ghi toàn bộ chuỗi JSON đó thành một file vật lý trên máy tính
        File.WriteAllText(saveFilePath, jsonString);
        
        Debug.Log("Đã GHI file save thành công tại: " + saveFilePath);
    }

    public void LoadGameFromFile()
    {
        // Phải kiểm tra xem file có tồn tại không trước khi đọc để tránh lỗi sập game
        if (File.Exists(saveFilePath))
        {
            // 1. Đọc toàn bộ nội dung chữ bên trong file
            string savedJson = File.ReadAllText(saveFilePath);

            // 2. Ép ngược chuỗi JSON đó thành Object PlayerData
            myData = JsonUtility.FromJson<PlayerData>(savedJson);

            Debug.Log("Đã ĐỌC file save thành công! Skin hiện tại: " + myData.candySkin);
            Debug.Log("Tổng số sao tải lên: " + myData.totalStars);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy file save nào! Bạn đã nhấn S để lưu chưa?");
        }
    }
}