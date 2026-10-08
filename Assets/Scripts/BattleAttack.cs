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
        skipLine = false;
        StartDialog(dialogTextlist[0] + "Spider for " + damageDealt.ToString() + " damage!", 0, -(enemyID));
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

        for (int i = startPos; i < dialog.Length; i++)
        {
            dialogue.text = dialog;
            while (skipLine == false)
            {
                yield return null;
            }
            if (endDialog == -1)
            {
                randomNumber = Random.Range(0,4);
                if (battleStats.enemyHealth > 0)
                {
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
                    break;
                }
                if (battleStats.enemyHealth <= 0)
                {
                    Debug.Log("The enemy was defeated!");
                    StartDialog("The " + battleStats.enemyName + " was defeated!", 0, 1);
                }
                
            } else if (endDialog == 1)
            {
                battle.EscapeToSelect(1);
                battleStats.WinCondition();
            }
            
        }
    }
}
