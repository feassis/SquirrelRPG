using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTokenGraphics : MonoBehaviour
{
    [SerializeField] private Image image;

    public void Setup(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
