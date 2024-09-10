using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenueUiHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
