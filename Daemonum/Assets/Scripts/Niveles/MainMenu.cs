using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    //Text click;
    //public Image image;
 

    // Start is called before the first frame update

    void Start()
    {
        //click = GetComponent<Text>();
        //StartCoroutine(FadeImage(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScene()
    {
        SceneManager.LoadScene("Dialogo");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Le has dado a exit");
        Application.Quit();
    }

    //public void parpadeo()
    //{
    //    while (true)
    //    {
    //        click.CrossFadeColor(Color.white, 1, false, true);
    //    }
    //}

    //public void OnButtonClick()
    //{
    //    // fades the image out when you click
        
    //}

    //IEnumerator FadeImage(bool fadeAway)
    //{
    //    // fade from opaque to transparent
    //    if (fadeAway)
    //    {
    //        // loop over 1 second backwards
    //        for (float i = 3; i >= 0; i -= Time.deltaTime)
    //        {
    //            // set color with i as alpha
    //            image.color = new Color(1, 1, 1, i);
    //            yield return null;
    //        }
    //        MainMenuScene();
    //    }
    //}
    }
