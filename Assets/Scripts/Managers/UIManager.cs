using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private RectTransform _playButton;


    #endregion

    #region Unity Callbacks

    private void Start()
    {
        _playButton.DOAnchorPos(new Vector2(0, 0), 0.5f);
    }

    private void Update()
    {
        

    }

    private void OnApplicationQuit()
    {
        
    }
    #endregion

    #region On Click Methods

    public void OnClick_PlayGameButton()
    {
        //Change the scene to gameplay
        SceneManager.LoadScene(1);
    }

    #endregion
}
