using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIAudioManager : MonoBehaviour
{
    // �ǳ� ��� ������Ʈ ����
    public GameObject EndPanel;
    public GameObject OptionPanel;
    public GameObject TutorialPanel;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI MyScore;
    public TextMeshProUGUI PlayerScore;
   

    // ����� ������ ������Ʈ

    public AudioSource BgmMusic;
    public AudioSource EffectSound;
    public AudioClip PopSound;
    public Slider BgmSlider;
    public Slider EffectSlider;
    // public AudioClip Effect; //����Ʈ ���� �߰� Ŭ��

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

    public void SetEndPanel() // ���� ������ ���
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

    public void SetOptionPanel() //�ɼ� ��ư Ŭ���� ���
    {
        bool IsSetOptionPanel = OptionPanel.activeSelf;
        OptionPanel.SetActive(!IsSetOptionPanel);
        if (!IsSetOptionPanel)
        {
            // �ǳ��� ��Ÿ�� �� �Ͻ�����
            Time.timeScale = 0f;
        }
        else
        {
            // �ǳ��� ����� �� �Ͻ����� ����
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

   
    //����Ʈ ���ھ� �ؽ�Ʈ ������Ʈ
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

    // ���� ���ھ� ������Ʈ
    public void UpdateMyScore()
    {
        
        MyScore.text = PlayPoint.ToString();
        PlayerScore.text = "����: " + GameManager.I.MergePoint.ToString();
        
    }
}
