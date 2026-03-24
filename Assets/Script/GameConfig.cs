using UnityEngine;

// Dòng này CỰC KỲ QUAN TRỌNG: Nó tạo ra một menu khi bạn nhấp chuột phải trong Unity
[CreateAssetMenu(fileName = "NewGameConfig", menuName = "Game Data/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Thông số Người chơi")]
    public float playerSpeed = 5.5f;
    public int startingLives = 3;

    [Header("Thông số Màn chơi")]
    public float gravityMultiplier = 1.0f;
    public int targetScoreToWin = 100;
}