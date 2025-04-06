using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterMenu : MonoBehaviour
{

    public Image oldImage;
    public Sprite newSprite;
    public Sprite subSprite;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    public void SpriteChange()
    {
        subSprite = oldImage.sprite;
        oldImage.sprite = newSprite;
        newSprite = subSprite;
    }
}
