using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioManager : MonoBehaviour
{
    // �ǳ� ��� ������Ʈ ����
    public GameObject EndPanel;
    public GameObject OptionPanel;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI MyScore;
    public TextMeshProUGUI PlayerScore;

    // ����� ������ ������Ʈ

    public AudioSource BgmMusic;
    public AudioSource EffectSound;
    public Slider BgmSlider;
    public Slider EffectSlider;
    // public AudioClip Effect; //����Ʈ ���� �߰� Ŭ��

    // Start is called before the first frame update
    void Start()
    {
        BgmMusic.volume = BgmSlider.value;
        EffectSound.volume = EffectSlider.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerScore();
    }

    public void SetEndPanel() // ���� ������ ���
    {
        bool IsSetEndPanel = EndPanel.activeSelf;
        EndPanel.SetActive(!IsSetEndPanel);
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

    public void OnChangeBgm()
    {
        BgmMusic.volume = BgmSlider.value;
    }

   
    public void OnChangeEffect()
    {
        EffectSound.volume = EffectSlider.value;
    }

    public void UpdatePlayerScore()
    {
        PlayerScore.text = "����: " + GameManager.I.MergePoint.ToString();
    }
    //����Ʈ ���ھ� �ؽ�Ʈ ������Ʈ
    //public void UpdateBestScore()
    //{
    //    if (BestScore.text == null)
    //    {
    //        BestScore.text = MyScore.text;
    //    }

    //    else if(BestScore < MyScore)
    //    {
    //        BestScore.text = MyScore.text;
    //    }

    //    else
    //    {
    //        BestScore.text = BestScore.text;
    //    }
    //}

    // ���� ���ھ� ������Ʈ
    //public void UpdateMyScore()
    //{
    //    MyScore.text = "";
    //}
}
