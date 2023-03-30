using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    // public byte[] playerScore;
    public byte[] posX;
    public byte[] posY;
}

public class SaveManager : MonoBehaviour {
    private string saveFileName = "savedata.json";
    private byte[] key = new byte[] { 0x01, 0x03, 0x05, 0x09 }; // The key can be anything

    public void SaveGame(float posX, float posY) {
        SaveData data = new SaveData();
        // data.playerScore = Encoding.UTF8.GetBytes(score.ToString());
        data.posX = Encoding.UTF8.GetBytes(posX.ToString());
        data.posY = Encoding.UTF8.GetBytes(posY.ToString());


        // XOR Encryption
        // for (int i = 0; i < data.playerScore.Length; i++) {
        //     data.playerScore[i] = (byte)(data.playerScore[i] ^ key[i % key.Length]);
        // }

        for (int i = 0; i < data.posX.Length; i++) {
            data.posX[i] = (byte)(data.posX[i] ^ key[i % key.Length]);
        }
        for (int i = 0; i < data.posY.Length; i++) {
            data.posY[i] = (byte)(data.posY[i] ^ key[i % key.Length]);
        }

        string jsonData = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        File.WriteAllText(filePath, jsonData);
    }

    public float[] LoadGame() {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(filePath)) {
            string jsonData = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            // XOR decryption
            // for (int i = 0; i < data.playerScore.Length; i++) {
            //     data.playerScore[i] = (byte)(data.playerScore[i] ^ key[i % key.Length]);
            // }
            for (int i = 0; i < data.posX.Length; i++) {
                data.posX[i] = (byte)(data.posX[i] ^ key[i % key.Length]);
            }
            for (int i = 0; i < data.posY.Length; i++) {
                data.posY[i] = (byte)(data.posY[i] ^ key[i % key.Length]);
            }

            // string scoreString = Encoding.UTF8.GetString(data.playerScore);
            // int score = 0;
            string posXString = Encoding.UTF8.GetString(data.posX);
            string posYString = Encoding.UTF8.GetString(data.posY);

            float posX = 0f;
            float posY = 0f;

            float.TryParse(posXString, out posX);
            float.TryParse(posYString, out posY);

            float[] positions = {posX, posY};

            return positions;
        } 
        else {
            return null;
        }
    }
}