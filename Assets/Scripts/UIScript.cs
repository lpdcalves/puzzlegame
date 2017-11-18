using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script para gerenciar os elementos gráficos da tela (tempo, dicas etc)
//o código ele não aparenta estar ligado ao resto do jogo mas ele se liga através dos objetos timerText e nomeLevel que são referenciado no unity
public class UIScript : MonoBehaviour {

	public Text timerText;
    public Text nomeLevel;
    private float startTime;
    

	// Use this for initialization
	void Start () {
        Debug.Log(SceneManager.GetActiveScene().name);
        if ((SceneManager.GetActiveScene().buildIndex != 0) || (SceneManager.GetActiveScene().name != "Credits"))
        {
            Scene cena = SceneManager.GetActiveScene();
            startTime = Time.time;
            nomeLevel.text = cena.name; //mostra o nome do nível (nível 1, 2, 3...)
            gameObject.transform.Find("pauseMenu").gameObject.SetActive(false); //inicia o jogo com o menu inativo
        }
    }
	
	// Update is called once per frame
	void Update () {

        if((SceneManager.GetActiveScene().buildIndex != 0) || (SceneManager.GetActiveScene().name != "Credits")) { 
		    float t = Time.time - startTime;

            string minutos = ((int)t / 60).ToString(); //transforma o tempo em minutos transformando ele em inteiro e depois dividindo por 60
            string segundos = (t % 60).ToString("f0"); //pega o resto da divisao de t por 60 para ter somente os segundos e limita o tamanho dessa string em dois

            //esses ifs são pra deixar o timer visualmente bonito... um dia eu penso numa forma de fazer isso mais eficientemente.
            if(int.Parse(minutos) < 10)
            {
                if (int.Parse(segundos) < 10)
                {
                    timerText.text = "0"+minutos + ":0" + segundos;
                }
                else
                {
                    timerText.text = "0" + minutos + ":" + segundos;
                }
            }

            else
            {
                if (int.Parse(segundos) < 10)
                {
                    timerText.text = minutos + ":0" + segundos;
                }
                else
                {
                    timerText.text = minutos + ":" + segundos;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (gameObject.transform.Find("pauseMenu").gameObject.activeInHierarchy == false) //se o menu não estiver ativo:
        {
            gameObject.transform.Find("pauseMenu").gameObject.SetActive(true); //ativa o menu
            Time.timeScale = 0;
        }
        else
        {
            gameObject.transform.Find("pauseMenu").gameObject.SetActive(false); //desativa o menu
            Time.timeScale = 1;
        }
    }

    //funções que são chamadas pelos botões do menu para mudar de fase e sair do jogo:

    public void menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void fase1()
    {
        SceneManager.LoadScene("Fase 1");
        Time.timeScale = 1;
    }
    public void fase2()
    {
        SceneManager.LoadScene("Fase 2");
        Time.timeScale = 1;
    }
    public void fase3()
    {
        SceneManager.LoadScene("Fase 3");
        Time.timeScale = 1;
    }
    public void fase4()
    {
        SceneManager.LoadScene("Fase 4");
        Time.timeScale = 1;
    }
    public void fase5()
    {
        SceneManager.LoadScene("Fase 5");
        Time.timeScale = 1;
    }
    public void credits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }
    public void sair()
    {
        Application.Quit();
    }
}
