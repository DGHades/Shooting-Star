using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FontManager : MonoBehaviour
{
    public TMP_FontAsset tMP_Font;
    public Material FontMat;
    public TextMeshProUGUI[] Text;
    void Start()
    {
        Text = FindObjectsOfType<TextMeshProUGUI>();
        foreach (var item in Text)
        {
            item.font = tMP_Font;
            item.fontMaterial = FontMat;
        }
    }
}
