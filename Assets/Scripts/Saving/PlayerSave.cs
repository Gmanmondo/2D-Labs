using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    private float posX;
    private float posY;
    private Transform playerPos;
    private SaveManager saveManager;

    void Start() {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        saveManager = FindObjectOfType<SaveManager>();
        // playerScore = saveManager.LoadGame();
        LoadPosiiton();
    }

    void Update() {
        posX = playerPos.position.x;
        posY = playerPos.position.y;


        if (Input.GetKeyDown(KeyCode.O)) {
            saveManager.SaveGame(posX, posY);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            // playerScore = saveManager.LoadGame();
            // print($"Saved score is: {playerScore}");
            LoadPosiiton();
        }
    }

    private void LoadPosiiton()
    {
        float[] positions = saveManager.LoadGame();
        posX = positions[0];
        posY = positions[1];

        playerPos.position = new Vector3(posX, posY, 0f);
    }
}