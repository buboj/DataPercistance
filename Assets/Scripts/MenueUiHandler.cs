using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using TMPro;

public class MenueUiHandler : MonoBehaviour
{   
    GameObject errorMessage;
    string inputPlayer;
    public TextMeshProUGUI BestMenueText;

    private void Start(){
        GameManager.Instance.LoadNameScore();
        errorMessage = GameObject.Find("NeedToEnterNAmeText");
        DisableFuckingText();
        BestMenueText.text = "Best Score: " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestScore;
    }

    public void StartNew(){
        if (inputPlayer != null && inputPlayer != ""){
            SceneManager.LoadScene(1);}
        else{
            errorMessage.GetComponent<TextMeshProUGUI>().enabled = true;
            StartCoroutine(ErrorTimer());
        }
    }

    public void DisableFuckingText(){
        errorMessage.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void Exit(){
        GameManager.Instance.SaveNameScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReadName(string s){
        GameManager.Instance.playerName = s;
        inputPlayer = s;
        StartNew();
    }

    IEnumerator ErrorTimer(){
        yield return new WaitForSeconds(2);
        DisableFuckingText();
    }

    public void ResetHightscore(){
        GameManager.Instance.bestPlayerName = "";
        GameManager.Instance.bestScore = 0;
        GameManager.Instance.oldBestScore =-1;
        GameManager.Instance.SaveNameScore();
        GameManager.Instance.LoadNameScore();
        BestMenueText.text = "Best Score: " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestScore;
    }

}
