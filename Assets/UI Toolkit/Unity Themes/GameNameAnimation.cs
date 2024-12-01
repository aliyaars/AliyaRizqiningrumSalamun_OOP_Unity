using UnityEngine;
using UnityEngine.UIElements;

public class GameNameAnimation : MonoBehaviour
{
    private Label gameTitleLabel;
    private VisualElement root;

    void Start()
    {
        // Mengambil root VisualElement dari UI Document
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        // Mendapatkan referensi ke Label menggunakan nama ID
        gameTitleLabel = root.Q<Label>("GameTitle");

        // Pastikan gameTitleLabel ditemukan
        if (gameTitleLabel != null)
        {
            // Menambahkan class untuk animasi pulsing dan glow
            gameTitleLabel.AddToClassList("pulse");
            gameTitleLabel.AddToClassList("glow");
        }
        else
        {
            Debug.LogError("Label dengan ID 'GameTitle' tidak ditemukan! Pastikan ID di UXML sudah benar.");
        }
    }
}
