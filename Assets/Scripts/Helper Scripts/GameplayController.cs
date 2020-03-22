using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public GameObject[] obstaclePrefabs;
    public GameObject[] potionPrefabs;
    public Transform[] lanes;
    public float min_ObstacleDelay = 10f, max_ObstacleDelay = 40f;
    private float halfGroundSize;
    private BaseController playerController;
    public Text txt_Coins;
    public Text totalCoins;
    public Slider HealthBar;

    private float ypos = 6f;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject gameover_Panel;
    

    [SerializeField]
    private Text final_Score;

    private GameObject UI_Holder;


    void Awake()
    {
        MakeInstance();
        coins = 0;
        txt_Coins.text = "POTION : " + coins;
        totalCoins.text = "Potions Collected : " + coins;

    }

	// Use this for initialization
	void Start () {

        halfGroundSize = GameObject.Find("Track").GetComponent<GroundBlock>().halfLength;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();
        HealthBar.value = playerController.Health / 100; // AddingHealth.
        UI_Holder = GameObject.Find("UI Panel");
        StartCoroutine("GenerateObstacles");
        //UI_Holder = GameObject.Find("UI panel");

    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator GenerateObstacles()
    {
        float timer = Random.Range(min_ObstacleDelay, max_ObstacleDelay) / playerController.speed.z;
        yield return new WaitForSeconds(timer);

        CreateObstacles(playerController.gameObject.transform.position.z + halfGroundSize/2);

        StartCoroutine("GenerateObstacles");
    }


    void CreateObstacles(float zPos)
    {
        int r = Random.Range(0, 10);

        if( r >= 0 && r < 10)
        {
            int obstacleLane = Random.Range(0, lanes.Length);

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x, -ypos,
                zPos), Random.Range(0, obstaclePrefabs.Length));

            int potionLane = 0;

            if (obstacleLane == 0)
            {
                potionLane = Random.Range(0, 2) == 1 ? 1 : 2;

            }
            else if (obstacleLane == 1)
            {
                potionLane = Random.Range(0, 2) == 1 ? 0 : 2;

            }
            else if (obstacleLane == 2)
            {
                potionLane = Random.Range(0, 2) == 1 ? 1 : 0;
            }
            
            Vector3 pospotion = new Vector3(lanes[potionLane].transform.position.x, -ypos, zPos);

            AddPotions(pospotion);
            //Debug.Log("potion created at " + pospotion);

        }
    }

    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle = (GameObject)Instantiate(obstaclePrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;

        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;

            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
        }

        obstacle.transform.position = position;

        //Debug.Log("obstacle created at " + obstacle.transform.position);

    }

    void AddPotions(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;

        for (int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(1f, 10f) * i);

            Instantiate(potionPrefabs[Random.Range(0, potionPrefabs.Length)],
                pos + shift * i, Quaternion.identity);
        }

        
    }


    int coins;
    public void FncCollectCoins()
    {
        coins++;

        txt_Coins.text = "POTION : " + coins;
        FncCollectEffect();
    }

    public void FncTakeDamage(float Damage)
    {


        if(playerController.Health > 0)
        {
            playerController.Health -= Damage;
            HealthBar.value = playerController.Health /100;
            FncEffect();
        }

        else
        {
            Time.timeScale = 0.0f;
            UI_Holder.SetActive(false);
            Gameover();
        }
    }


    void FncEffect()
    {
        playerController.Hit_Effect.SetActive(true);

        Invoke("FncEffectCancle", 1f);
    }

    void FncEffectCancle()
    {
        playerController.Hit_Effect.SetActive(false);
    }

    void FncCollectEffect()
    {
        playerController.CollectEffect.SetActive(true);

        Invoke("FncCollectEffectCancle", 1f);
    }

    void FncCollectEffectCancle()
    {
        playerController.CollectEffect.SetActive(false);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        totalCoins.text = "Potions Collected : " + coins;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Gameover()
    {
        Time.timeScale = 0f;
        final_Score.text = "Total Potions Collected: " + coins;
        gameover_Panel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("current");
    }
}
