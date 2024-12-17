using UnityEngine;
using UnityEngine.UI;


public class ColorSelectionButton : MonoBehaviour
{

    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer1 = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorPlayer2 = paddleReference.color;
        }
    }
}
