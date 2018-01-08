using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject MessageBox;
    public EventInfo Temp;

    private GameManager _theGameManager;
    private TargetLocation _ashPark,
                           _freemason,
                           _philmont,
                           _quinnSquare,
                           _eastBeaHeights;
    private Text _title,
                 _messageText;

    private void Start()
    {
        _title = MessageBox.transform.Find("Title").GetComponent<Text>();
        _messageText = MessageBox.transform.Find("Title/MessageText").GetComponent<Text>();
        MessageBox.SetActive(false);
        _theGameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _ashPark = GameObject.Find("WorldMap/Ash Park").GetComponent<TargetLocation>();
        _freemason = GameObject.Find("WorldMap/Freemason").GetComponent<TargetLocation>();
        _philmont = GameObject.Find("WorldMap/Philmont").GetComponent<TargetLocation>();
        _quinnSquare = GameObject.Find("WorldMap/Quinn Square").GetComponent<TargetLocation>();
        _eastBeaHeights = GameObject.Find("WorldMap/East Bea Heights").GetComponent<TargetLocation>();
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
        EventEffect EE = messageEvent.TheEventEffect;
        for (int i = 0; i < EE.LocationToAffect.Count; i++)
        {
            switch (EE.LocationToAffect[i])
            {
                case Locations.GLOBAL:
                    switch(EE.StatToChange[i])
                    {
                        case Stats.CRIMERATE:
                            _theGameManager.WorldCrimeRate += EE.StatChange[i];
                            break;
                        case Stats.STIRATE:
                            _theGameManager.WorldSTIRate += EE.StatChange[i];
                            break;
                        case Stats.TEENPREGRATE:
                            _theGameManager.WorldTeenPregRate += EE.StatChange[i];
                            break;
                        case Stats.FINANCE:
                            _theGameManager.Finance += EE.StatChange[i];
                            break;
                        case Stats.EDUCATION:
                            _theGameManager.Education += EE.StatChange[i];
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.ASHPARK:
                    switch (EE.StatToChange[i])
                    {
                        case Stats.CRIMERATE:
                            _ashPark.CrimeRate += EE.StatChange[i];
                            break;
                        case Stats.STIRATE:
                            _ashPark.STIRate += EE.StatChange[i];
                            break;
                        case Stats.TEENPREGRATE:
                            _ashPark.TeenPregRate += EE.StatChange[i];
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.EASTBEAHEIGHTS:
                    switch (EE.StatToChange[i])
                    {
                        case Stats.CRIMERATE:
                            _eastBeaHeights.CrimeRate += EE.StatChange[i];
                            break;
                        case Stats.STIRATE:
                            _eastBeaHeights.STIRate += EE.StatChange[i];
                            break;
                        case Stats.TEENPREGRATE:
                            _eastBeaHeights.TeenPregRate += EE.StatChange[i];
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.FREEMASON:
                    switch (EE.StatToChange[i])
                    {
                        case Stats.CRIMERATE:
                            _freemason.CrimeRate += EE.StatChange[i];
                            break;
                        case Stats.STIRATE:
                            _freemason.STIRate += EE.StatChange[i];
                            break;
                        case Stats.TEENPREGRATE:
                            _freemason.TeenPregRate += EE.StatChange[i];
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.PHILMONT:
                    switch (EE.StatToChange[i])
                    {
                        case Stats.CRIMERATE:
                            _philmont.CrimeRate += EE.StatChange[i];
                            break;
                        case Stats.STIRATE:
                            _philmont.STIRate += EE.StatChange[i];
                            break;
                        case Stats.TEENPREGRATE:
                            _philmont.TeenPregRate += EE.StatChange[i];
                            break;
                        default:
                            break;
                    }
                    break;
                case Locations.QUINNSQUARE:
                    switch (EE.StatToChange[i])
                    {
                        case Stats.CRIMERATE:
                            _quinnSquare.CrimeRate += EE.StatChange[i];
                            break;
                        case Stats.STIRATE:
                            _quinnSquare.STIRate += EE.StatChange[i];
                            break;
                        case Stats.TEENPREGRATE:
                            _quinnSquare.TeenPregRate += EE.StatChange[i];
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}