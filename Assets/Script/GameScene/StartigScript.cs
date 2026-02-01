using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class StartigScript : MonoBehaviour
{
    public static StartigScript instance;
    public int countNumber;
    public Animator animator;
    public GameObject rightPanel, leftPanel, nextRoundPanel,winnerPanel,descriptionPanal,gameOverPanel;
    public TextMeshProUGUI clueTest;
    public GameObject clueTestgameObject;
    public List<Sprite> body = new List<Sprite>();
    public Image bodyImage;
    public int chekingNum;
    public HeadSnapPoint headSnapPoint;
    public TextMeshProUGUI artHeading;
    public TextMeshProUGUI artBody;
    public GameObject timer;
    public int incorrectFaceCount;
    /*public List<GameObject> cutpeacePos= new List<GameObject>();
    public List<GameObject> cutpeaceEmptyPos= new List<GameObject>()*/


    //public List<TextMeshProUGUI> clue = new List<TextMeshProUGUI>();

    private void Awake()
    {
        instance = this;
        animator.enabled = false;
    }
    public void NextRoundPanelActive()
    {
     int randomNum = Random.Range(0, 4);
        chekingNum = randomNum;


        if (nextRoundPanel.activeInHierarchy == true)
        {
            if(randomNum == 0)
            {
                clueTest.text = "Which dance-drama uses eye and facial expressions to tell epic stories".ToString();
                bodyImage.sprite = body[0];
                headSnapPoint.correctBodyID = 0;
                artHeading.text = " KADHAKALI ".ToString();
                artHeading.text = " Kathakali is a classical dance-drama from Kerala, known for its bold makeup, large headgear, and expressive eye movements. It tells stories from Indian epics like the Ramayana and Mahabharata. ".ToString();

            }
            // clueTest = clue[randomNum];
            else if (randomNum == 1)
            {
                clueTest.text = "Which traditional performance features fire, intense movements, and ritual costumes?".ToString();
                bodyImage.sprite = body[1];
                headSnapPoint.correctBodyID = 1;
                artHeading.text = " THEYYAM ".ToString();
                artHeading.text = " Theyyam is a ritual art form of North Kerala, where the performer is believed to become the deity during the performance. It features fiery costumes, face painting, and powerful movements. ".ToString();

            }
            else if (randomNum == 2)
            {
                clueTest.text = "Which traditional art form uses storytelling with dramatic makeup and costumes?".ToString();
                bodyImage.sprite = body[2];
                headSnapPoint.correctBodyID = 2;
                artHeading.text = " YAKSHAGANA ".ToString();
                artHeading.text = " Yakshagana is a vibrant theatre dance form from Karnataka, combining dance, music, dialogue, and colorful costumes. Performances usually happen at night and narrate mythological stories. ".ToString();
            }
            else if (randomNum == 3)
            {
                clueTest.text = "Which solo dance form is known for humor and satire?".ToString();
                bodyImage.sprite = body[3];
                headSnapPoint.correctBodyID = 3;
                artHeading.text = " OTTAM THULLAL ".ToString();
                artHeading.text = "Ottam Thullal is a humorous solo dance from Kerala, created to entertain and educate people. It uses simple makeup, rhythmic movements, and satire to tell stories in a lively way. ".ToString();

            }
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
