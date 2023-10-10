using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void Default()
    {
        GameManager.Instance.characterSelected = 0;
        SceneManager.LoadScene("MainGame");
    }

    public void Tank()
    {
        GameManager.Instance.characterSelected = 1;
        SceneManager.LoadScene("MainGame");
    }

    public void Speed()
    {
        GameManager.Instance.characterSelected = 2;
        SceneManager.LoadScene("MainGame");
    }
}
