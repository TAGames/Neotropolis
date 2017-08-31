using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }

    public string npcName;

    public GameObject dialoguePanel;
    public GameObject selectPanel;
    public GameObject buttonPref;
    public float scrollSpeed = 2f;


    EventSystem eventSystem;
    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;
    GameObject choiceContentPanel;
    GameObject scrollVertiGO;
    Scrollbar scrollbarVerti;

    public List<string> dialogueLines = new List<string>();
    
    void Awake () {
        continueButton = dialoguePanel.transform.GetChild(0).GetComponent<Button>();
        dialogueText = dialoguePanel.transform.GetChild(1).GetComponent<Text>();
        nameText = dialoguePanel.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        scrollVertiGO = selectPanel.transform.GetChild(2).gameObject;
        scrollbarVerti = scrollVertiGO.GetComponent<Scrollbar>();

        eventSystem = EventSystem.current;
        dialoguePanel.SetActive(false);
        if(selectPanel != null)
        {
            selectPanel.SetActive(false);
            choiceContentPanel = selectPanel.transform.GetChild(0).transform.GetChild(0).gameObject;
        }

        // stellt sicher das nur ein Object sein kann
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        removeChoices();
        StopStartPlayerMovement(false);
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        
        if (selectPanel != null && selectPanel.activeSelf)
        {
            eventSystem.SetSelectedGameObject(choiceContentPanel.transform.GetChild(0).gameObject);
        }
        else
        {
            eventSystem.SetSelectedGameObject(continueButton.gameObject);
        }
        
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            if(selectPanel != null)
            {
                selectPanel.SetActive(false);
                removeChoices();
            }
            StopStartPlayerMovement(true);
        }
    }
    public void AddChoice(string choiceName, UnityEngine.Events.UnityAction method)
    {
        selectPanel.SetActive(true);
        continueButton.gameObject.SetActive(true);
        GameObject button = Instantiate(buttonPref,choiceContentPanel.transform);
        button.GetComponent<ButtonScript>().label.text = choiceName;
        button.GetComponent<Button>().onClick.AddListener(method);
    }
    public void removeChoices()
    {
        for (int i = 0; i < choiceContentPanel.transform.childCount; i++)
        {
            Destroy(choiceContentPanel.transform.GetChild(i).gameObject);
        }
            
    }
    public void CloseDialogue()
    {
        if (selectPanel != null)
        {
            selectPanel.SetActive(false);
            removeChoices();
        }
        dialoguePanel.SetActive(false);
        StopStartPlayerMovement(true);
        continueButton.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
    }

    public void StopStartPlayerMovement(bool start)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.GetComponent<Character3DController>() != null)
        {
            player.GetComponent<Character3DController>().allowMovement = start;
        }

    }
    public void HighlightButton()
    {
        eventSystem.SetSelectedGameObject(choiceContentPanel.transform.GetChild(0).gameObject);
    }
    public void DisableContinue()
    {
        continueButton.gameObject.SetActive(false);
    }
    public void AutoScroll()
    {
        scrollVertiGO = selectPanel.transform.GetChild(2).gameObject;
        scrollbarVerti = scrollVertiGO.GetComponent<Scrollbar>();
        if (scrollVertiGO.activeSelf && eventSystem.currentSelectedGameObject != null)
        {
            if(eventSystem.currentSelectedGameObject.transform.position.y + scrollSpeed < selectPanel.transform.position.y && scrollbarVerti.value > 0)
            {
                choiceContentPanel.transform.position = new Vector2(choiceContentPanel.transform.position.x, choiceContentPanel.transform.position.y + 1 * scrollSpeed);
            }
            else if(eventSystem.currentSelectedGameObject.transform.position.y - scrollSpeed > selectPanel.transform.position.y && scrollbarVerti.value < 1)
            {
                choiceContentPanel.transform.position = new Vector2(choiceContentPanel.transform.position.x, choiceContentPanel.transform.position.y - 1 * scrollSpeed);
            }
        }
    }
    void Update()
    {
        AutoScroll();
    }
}
