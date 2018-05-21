using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject MessageBox;
    public SpriteRenderer CloseButtonSprite;

    private GameManager _theGameManager;
    private TutorialToolTipManager _theTTTMan;
    private TargetLocation _ashPark,
                           _freemason,
                           _philmont,
                           _quinnSquare,
                           _eastBeaHeights;
    private Text _title,
                 _messageText;
    private bool _firstMessageDisplayed;

    private void Start()
    {
        _title = MessageBox.transform.Find("Title").GetComponent<Text>();
        _messageText = MessageBox.transform.Find("Title/MessageText").GetComponent<Text>();
        MessageBox.SetActive(false);
        _theGameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _ashPark = GameObject.Find("World Map/Ash Park").GetComponent<TargetLocation>();
        _freemason = GameObject.Find("World Map/Freemason").GetComponent<TargetLocation>();
        _philmont = GameObject.Find("World Map/Philmont").GetComponent<TargetLocation>();
        _quinnSquare = GameObject.Find("World Map/Quinn Square").GetComponent<TargetLocation>();
        _eastBeaHeights = GameObject.Find("World Map/East Bea Heights").GetComponent<TargetLocation>();
        _theTTTMan = FindObjectOfType<TutorialToolTipManager>();
    }

    public void ShowMessage(EventInfo messageEvent)
    {
        if (!_firstMessageDisplayed)
        {
            _firstMessageDisplayed = true;

            _theTTTMan.ShowPopUp("EventHappens", 0.2f);
        }

        MessageBox.SetActive(true);
        _title.text = messageEvent.EventTitle;
        _messageText.text = messageEvent.EventText;
        Locations randLoc = Locations.RANDOM;

        if (messageEvent.TheEventEffect.LocationToAffect[0] == Locations.RANDOM)
        {
            randLoc = RandomizeLocation();
            AddLocationInfo(randLoc.ToString());
        }
        
        if(messageEvent.TheEventEffect != null)
        {
            EventEffect EE = messageEvent.TheEventEffect;

            for (int i = 0; i < EE.LocationToAffect.Count; i++)
            {
                switch (EE.LocationToAffect[i])
                {
                    case Locations.GLOBAL:
                        switch (EE.StatToChange[i])
                        {
                            case Stats.CRIMERATE:
                                _ashPark.CrimeRate += EE.StatChange[i];
                                _eastBeaHeights.CrimeRate += EE.StatChange[i];
                                _freemason.CrimeRate += EE.StatChange[i];
                                _philmont.CrimeRate += EE.StatChange[i];
                                _quinnSquare.CrimeRate += EE.StatChange[i];
                                break;
                            case Stats.STIRATE:
                                _ashPark.STIRate += EE.StatChange[i];
                                _eastBeaHeights.STIRate += EE.StatChange[i];
                                _freemason.STIRate += EE.StatChange[i];
                                _philmont.STIRate += EE.StatChange[i];
                                _quinnSquare.STIRate += EE.StatChange[i];
                                break;
                            case Stats.TEENPREGRATE:
                                _ashPark.TeenPregRate += EE.StatChange[i];
                                _eastBeaHeights.TeenPregRate += EE.StatChange[i];
                                _freemason.TeenPregRate += EE.StatChange[i];
                                _philmont.TeenPregRate += EE.StatChange[i];
                                _quinnSquare.TeenPregRate += EE.StatChange[i];
                                break;
                            case Stats.BUDGET:
                                _theGameManager.Budget += EE.StatChange[i];
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
                    case Locations.RANDOM:
                        switch(randLoc)
                        {
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

    private Locations RandomizeLocation()
    {
        Locations newLoc = Locations.ASHPARK;

        int rand = Random.Range(0, 5);
        if (rand == 0)
        {
            newLoc = Locations.ASHPARK;
        }
        else if (rand == 1)
        {
            newLoc = Locations.FREEMASON;
        }
        else if (rand == 2)
        {
            newLoc = Locations.PHILMONT;
        }
        else if (rand == 3)
        {
            newLoc = Locations.QUINNSQUARE;
        }
        else if (rand == 4)
        {
            newLoc = Locations.EASTBEAHEIGHTS;
        }

        return newLoc;
    }

    private void AddLocationInfo(string location)
    {
        string newMessage = "",
               locName = "";
        
        switch (location)
        {
            case "ASHPARK":
                locName = "Ash Park";
                break;
            case "FREEMASON":
                locName = "Freemason";
                break;
            case "PHILMONT":
                locName = "Philmont";
                break;
            case "QUINNSQUARE":
                locName = "Quinn Square";
                break;
            case "EASTBEAHEIGHTS":
                locName = "East Bea Heights";
                break;
            default:
                break;
        }

        for (int i = 0; i < _messageText.text.Length; i++)
        {
            if (_messageText.text[i] != '*')
                newMessage += _messageText.text[i];
            else
                newMessage += locName;
        }

        _messageText.text = newMessage;
    }

    public void HighlightOn()
    {
        CloseButtonSprite.color = new Color(CloseButtonSprite.color.r + 0.31f, CloseButtonSprite.color.g + 0.31f, CloseButtonSprite.color.b + 0.31f);
    }

    public void HighlightOff()
    {
        CloseButtonSprite.color = new Color(CloseButtonSprite.color.r - 0.31f, CloseButtonSprite.color.g - 0.31f, CloseButtonSprite.color.b - 0.31f);
    }

    public void HideMessage()
    {
        MessageBox.SetActive(false);

        TutorialToolTip currentTTT = FindObjectOfType<TutorialToolTip>();

        if (currentTTT)
        {
            if (currentTTT.name == "EventHappens(Clone)")
            {
                EventManager.TriggerEvent("Close");
            }
        }
    }
}