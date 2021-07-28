using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private NetworkController m_NetworkController;
    public int m_highlightedFontSize = 52;
    public int m_defaultFontSize = 50;
    public AudioSource m_audioSource;
    public AudioClip m_audioHighlight;
    public AudioClip m_audioConfirm;
    
    public void Awake()
    {
        m_NetworkController = GetComponent<NetworkController>();
    }

    public void createRoom()
    {
        m_audioSource.PlayOneShot(m_audioConfirm);
        m_NetworkController.Connect();
    }

    public void highlightButton(Button button)
    {
        Text buttonText = button.transform.Find("Text").GetComponent<Text>();
        if(buttonText.fontSize == m_defaultFontSize)
        {
            buttonText.fontSize = m_highlightedFontSize;
            m_audioSource.PlayOneShot(m_audioHighlight);
        }
        else
            buttonText.fontSize = m_defaultFontSize;
    }    
    
}
