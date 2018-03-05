using UnityEngine;
using System.Collections;

public class OnHover : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color defaultColor;
    public Color color;

    // Use this for initialization
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HighlightOn()
    {
        sprite.color = color;
    }

    public void HighlightOff()
    {
        sprite.color = defaultColor;
    }
}