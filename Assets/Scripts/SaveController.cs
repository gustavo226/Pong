using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.StickyNote;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer1 = Color.white;
    public Color colorPlayer2 = Color.white;

    private static SaveController _instance;

    public string namePlayer1;
    public string namePlayer2;

    private string saveWinnerKey = "SavedWinner";

    // Propriedade est�tica para acessar a inst�ncia

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a inst�ncia na cena
                _instance = FindObjectOfType<SaveController>();

                // Se n�o encontrar, crie uma nova inst�ncia
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Garanta que apenas uma inst�ncia do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer1 : namePlayer2;
    }

    public void Reset()
    {
        namePlayer1 = "";
        namePlayer2 = "";
        colorPlayer1 = Color.white;
        colorPlayer2 = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
