using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAttack : MonoBehaviour
{
    public static BattleAttack instance;

    [SerializeField] List<string> dialogTextlist;
    [SerializeField] List<GameObject> disableDialogTextlist;
    [SerializeField] List<GameObject> enableDialogTextlist;
    int randomNumber;
    public BattleStats battleStats;
    public BattleSelect battle;
    public GameObject battleBox;
    public GameObject dialogText;
    public List<GameObject> attackObjects;
    public MenuSelect shop;
    private float scaleX = 7;
    private float scaleY = 3;
    public bool inDialog;
    public bool skipLine;
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inDialog)
            {
                skipLine = true;
                for (int i = 0; i < enableDialogTextlist.Count; i++)
                {
                    enableDialogTextlist[i].SetActive(false);
                }
                for (int i = 0; i < disableDialogTextlist.Count; i++)
                {
                    disableDialogTextlist[i].SetActive(true);
                }
            }
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }
    public void Attack(int enemyID, float damageDealt)
    {
        damageDealt = damageDealt * Random.Range(0.8f,1.2f);
        skipLine = false;
        StartDialog(dialogTextlist[0] + $"{battleStats.enemyName}" + " for " + ((int)(damageDealt)).ToString() + " damage!", 0, -(enemyID));
        battleStats.enemyHealth -= damageDealt;
    }

    public void StartDialog(string dialog, int startPos, int endDialog)
    {
        inDialog = true;
        dialogText.SetActive(true);
        skipLine = false;
        for (int i = 0; i < disableDialogTextlist.Count; i++)
        {
            disableDialogTextlist[i].SetActive(false);
        }
        for (int i = 0; i < enableDialogTextlist.Count; i++)
        {
            enableDialogTextlist[i].SetActive(true);
        }
        battleBox.transform.localScale = new Vector3(scaleX,scaleY,1);
        battleBox.transform.localScale = new Vector3(13,5,1);
        battleBox.transform.position = new Vector3(0f,3.9f,89.9f);

        StopAllCoroutines();
        StartCoroutine(Dialog(dialog,startPos, endDialog));
    }
    IEnumerator Dialog(string dialog, int startPos, int endDialog)
    {
        TMPro.TextMeshProUGUI dialogue = dialogText.GetComponent<TMPro.TextMeshProUGUI>();
            dialogue.text = dialog;
            while (skipLine == false)
            {
                yield return null;
            }

            if (endDialog == 1)
            {
                if (battleStats.enemyHealth <= 0)
                {
                    StartDialog("The " + battleStats.enemyName + " was defeated!", 0, 2);
                }
                else
                {
                    battle.EscapeToSelect(1);
                    battleStats.WinCondition();
                }
            }
            if (endDialog == 2)
            {
                shop.coinStash += 100;
                StartDialog("You earned 100 coins!", 0, 3);
            }
            if (endDialog == 3)
                {
                    battle.EscapeToSelect(1);
                    battleStats.WinCondition();
                }

            if (endDialog == -1)
            {
                randomNumber = Random.Range(0,4);
                switch(randomNumber)
                {
                    case 1:
                        StartDialog(dialogTextlist[1], 0, 1);
                        break;
                    case 2:
                        StartDialog(dialogTextlist[2], 0, 1);
                        battleStats.player.playerHealth -= 5;
                        battleStats.UpdateHealth();
                        break;
                    case 3:
                        StartDialog(dialogTextlist[3], 0, 1);
                        battleStats.player.playerHealth -= 5;
                        battleStats.UpdateHealth();
                        break;
                    default:
                        StartDialog(dialogTextlist[1], 0, 1);
                        break;
                }
            } 

            if (endDialog == -2)
            {
                randomNumber = Random.Range(1, 7);
                switch(randomNumber)
                {
                    case 1:
                        StartDialog(dialogTextlist[4], 0, 1);
                        break;
                    case 2:
                        StartDialog(dialogTextlist[5], 0, 1);
                        battleStats.player.playerHealth -= Random.Range(5,11);
                        battleStats.UpdateHealth();
                        break;
                    case 3:
                        StartDialog(dialogTextlist[6], 0, 1);
                        battleStats.player.playerHealth -= Random.Range(9,14);
                        battleStats.UpdateHealth();
                        break;
                    case 4:
                        StartDialog(dialogTextlist[7], 0, 1);
                        break;
                    case 5:
                        StartDialog(dialogTextlist[8], 0, 1);
                        break;
                    case 6:
                        StartDialog(dialogTextlist[9], 0, 1);
                        break;
                    default:
                        StartDialog(dialogTextlist[1], 0, 1);
                        break;
                }
            }
        }
    }
