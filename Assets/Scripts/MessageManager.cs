using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject MessageBox;
    public EventInfo Temp;

    private Text _title,
                 _messageText;

    private void Start()
    {
        _title = MessageBox.transform.Find("Title").GetComponent<Text>();
        _messageText = MessageBox.transform.Find("Title/MessageText").GetComponent<Text>();
        MessageBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ShowMessage(Temp);
    }

    public void ShowMessage(EventInfo messageEvent)
    {
        MessageBox.SetActive(true);
        _title.text = messageEvent.EventTitle;
        _messageText.text = messageEvent.EventText;

        //Event effect stuff here
    }
}