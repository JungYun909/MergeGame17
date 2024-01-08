using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIAudioManager : MonoBehaviour
{
    // 판넬 띄울 오브젝트 설정
    public GameObject EndPanel;
    public GameObject OptionPanel;
    public GameObject TutorialPanel;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI MyScore;
    public TextMeshProUGUI PlayerScore;
   

    // 오디오 관리할 오브젝트

    public AudioSource BgmMusic;
    public AudioSource EffectSound;
    public AudioClip PopSound;
    public Slider BgmSlider;
    public Slider EffectSlider;
    // public AudioClip Effect; //이펙트 사운드 추가 클립

    private int BestPoint;
    private int PlayPoint;

    // Start is called before the first frame update
    void Start()
    {
        BgmMusic.volume = BgmSlider.value;
        EffectSound.volume = EffectSlider.value;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayPoint = GameManager.I.MergePoint;
        UpdateMyScore();
        UpdateBestScore();      
    }

    public void SetEndPanel() // 게임 오버시 사용
    {
        bool IsSetEndPanel = EndPanel.activeSelf;
        EndPanel.SetActive(!IsSetEndPanel);
        if (!IsSetEndPanel)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SetTutorial()
    {
        bool IsSetTutorialPanel = TutorialPanel.activeSelf;
        TutorialPanel.SetActive(!IsSetTutorialPanel);
        if(!IsSetTutorialPanel)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }        
    }

    public void SetOptionPanel() //옵션 버튼 클릭시 사용
    {
        bool IsSetOptionPanel = OptionPanel.activeSelf;
        OptionPanel.SetActive(!IsSetOptionPanel);
        if (!IsSetOptionPanel)
        {
            // 판넬이 나타날 때 일시정지
            Time.timeScale = 0f;
        }
        else
        {
            // 판넬이 사라질 때 일시정지 해제
            Time.timeScale = 1f;
        }
    }

    //public void LoadStartScene()
    //{
    //    SceneManager.LoadScene("StartScene");
    //}
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("JungYunScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnChangeBgm()
    {
        BgmMusic.volume = BgmSlider.value;
    }

   
    public void OnChangeEffect()
    {
        EffectSound.volume = EffectSlider.value;
    }

    public void OnPlayPopEffect()
    {
        EffectSound.PlayOneShot(PopSound);
    }

   
    //베스트 스코어 텍스트 업데이트
    public void UpdateBestScore()
    {
        if (PlayerPrefs.HasKey("MyBestScore") == false)
        {
            BestPoint = GameManager.I.MergePoint;
            PlayerPrefs.SetInt("MyBestScore", BestPoint);
        }             

        else
        {
            if(PlayerPrefs.GetInt("MyBestScore") < GameManager.I.MergePoint)
            {
                PlayerPrefs.SetInt("MyBestScore", GameManager.I.MergePoint);
                BestPoint = GameManager.I.MergePoint;
            }
        }
        BestScore.text = PlayerPrefs.GetInt("MyBestScore").ToString();
    }

    // 마이 스코어 업데이트
    public void UpdateMyScore()
    {
        
        MyScore.text = PlayPoint.ToString();
        PlayerScore.text = "점수: " + GameManager.I.MergePoint.ToString();
        
    }
}
