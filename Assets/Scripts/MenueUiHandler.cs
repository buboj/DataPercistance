using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using TMPro;

public class MenueUiHandler : MonoBehaviour
{   
    GameObject errorMessage;
    string inputPlayer;

    private void Start(){
        errorMessage = GameObject.Find("NeedToEnterNAmeText");
        DisableFuckingText();
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
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReadName(string s){
        GameManager.Instance.playerName = s;
        inputPlayer = s;
    }

    IEnumerator ErrorTimer(){
        yield return new WaitForSeconds(2);
        DisableFuckingText();
    }

}
