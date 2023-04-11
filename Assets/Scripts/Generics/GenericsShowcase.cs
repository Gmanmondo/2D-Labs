using UnityEngine;

public class GenericsShowcase : MonoBehaviour
{
    private int[] intArr = { 1, 2, 3 };
    private float[] floatArr = { 0.5f, 1.6f, 2.7f };
    private string[] strArr = { "Yeppers", "Noppers", "Indeeders" };

    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            DisplayElementsStinky(intArr);
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            DisplayElementsGood(intArr);
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            DisplayElementsGood(floatArr);
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            DisplayElementsGood(strArr);
        }
    }

    public void DisplayElementsStinky(int[] arr) {
        foreach (int item in arr) {
            print(item);
        }
    }

    public void DisplayElementsGood<Thingy>(Thingy[] arr) {
        foreach (Thingy thing in arr) {
            print(thing);
        }
    }
}
