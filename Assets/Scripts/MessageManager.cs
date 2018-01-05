using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject MessageBox;

    private Text _title,
                 _messageText;

    private void Start()
    {
        _title = MessageBox.transform.Find("Title").GetComponent<Text>();
    }

    public void ShowMessage(EventInfo messageEvent)
    {

    }
}