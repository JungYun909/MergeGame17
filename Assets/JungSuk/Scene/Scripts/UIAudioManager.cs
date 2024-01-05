using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioManager : MonoBehaviour
{
    // 판넬 띄울 오브젝트 설정
    public GameObject EndPanel;
    public GameObject OptionPanel;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI MyScore;
    public TextMeshProUGUI PlayerScore;

    // 오디오 관리할 오브젝트

    public AudioSource BgmMusic;
    public AudioSource EffectSound;
    public Slider BgmSlider;
    public Slider EffectSlider;
    // public AudioClip Effect; //이펙트 사운드 추가 클립

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

    public void SetEndPanel() // 게임 오버시 사용
    {
        bool IsSetEndPanel = EndPanel.activeSelf;
        EndPanel.SetActive(!IsSetEndPanel);
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
        PlayerScore.text = "점수: " + GameManager.I.MergePoint.ToString();
    }
    //베스트 스코어 텍스트 업데이트
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

    // 마이 스코어 업데이트
    //public void UpdateMyScore()
    //{
    //    MyScore.text = "";
    //}
}
