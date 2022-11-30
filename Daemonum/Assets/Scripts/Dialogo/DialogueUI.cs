using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private Image Lorey;
    [SerializeField] private Image Sombrero;

    private TypewriterEffect typewritterEffect;
    private bool loreyHabla = false;

    private void Start()
    {
       Lorey.enabled = false;
       typewritterEffect = GetComponent<TypewriterEffect>();
       CloseDialogueBox();
       ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            
            if(loreyHabla)
            {
                Sombrero.enabled = false;
                Lorey.enabled = true;
                loreyHabla = false;
            }
            else
            {
                Sombrero.enabled = true;
                Lorey.enabled = false;
                loreyHabla = true;
            }
            yield return typewritterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            AudioManager.instance.NextDialogoSFX();
        }
        CloseDialogueBox();
        SceneManager.LoadScene("Game");
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
