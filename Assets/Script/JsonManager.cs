using UnityEngine;

public class JsonManager : MonoBehaviour
{
    // Hiển thị ra Inspector để bạn dễ quan sát
    public PlayerData myData; 

    void Start()
    {
        // Khởi tạo dữ liệu mới
        myData = new PlayerData();
    }

    void Update()
    {
        // Bấm phím S để LƯU (Save) thành JSON
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Thay đổi một chút dữ liệu trước khi lưu để thấy sự khác biệt
            myData.totalStars = 15;
            myData.unlockedLevels.Add(2); 
            myData.unlockedLevels.Add(3);

            // 1. Biến object myData thành một chuỗi văn bản JSON
            string jsonString = JsonUtility.ToJson(myData);
            
            Debug.Log("Đã nén thành chuỗi JSON: \n" + jsonString);

            // 2. Lưu tạm chuỗi JSON này vào PlayerPrefs (Ở Lab 6 ta sẽ lưu ra File cứng sau)
            PlayerPrefs.SetString("SaveData", jsonString);
            PlayerPrefs.Save();
        }

        // Bấm phím L để ĐỌC (Load) từ JSON
        if (Input.GetKeyDown(KeyCode.L))
        {
            // 1. Lấy chuỗi JSON đã lưu lên
            string savedJson = PlayerPrefs.GetString("SaveData", "");

            if (savedJson != "")
            {
                // 2. Giải nén chuỗi JSON ngược lại thành object PlayerData
                myData = JsonUtility.FromJson<PlayerData>(savedJson);
                
                Debug.Log("Đã giải nén JSON thành công! Tổng số sao đang có: " + myData.totalStars);
            }
            else
            {
                Debug.Log("Không tìm thấy dữ liệu save nào!");
            }
        }
    }
}