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
    //Make this public and also the other vvv
    void OnMouseOver()
    {
        sprite.color = color;
    }

    void OnMouseExit()
    {
        sprite.color = defaultColor;
    }
}