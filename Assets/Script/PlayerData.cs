using System;
using System.Collections.Generic;

// BẮT BUỘC PHẢI CÓ dòng này để Unity hiểu và cho phép chuyển đổi class này sang JSON
[Serializable] 
public class PlayerData
{
    public string playerName;
    public int totalStars;
    public string candySkin;
    public List<int> unlockedLevels; 

    // Constructor để tạo dữ liệu mặc định khi người chơi mới tải game
    public PlayerData()
    {
        playerName = "Player_1";
        totalStars = 0;
        candySkin = "Default_Red_Candy";
        unlockedLevels = new List<int> { 1 }; // Mặc định chỉ mở khóa level 1
    }
}