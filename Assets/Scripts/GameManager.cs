using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    bool gameHasEnded = false;
    public GameObject Obstacle;
    public GameObject PowerUp;
    public Transform Player;
    public GameObject Ground;
    public Transform GroundTranform;
    private int[] SpawnPoints = new int[] { 2, 4, 6, 8, 10, 12, 14};
    private int[] PlacesSpawned = new int[8];
    private int NumberOfBoxes;
    private int PreviousX;
    private int CurrentXValue;
    private int XOffset;
    private int PowerUpChance ;
    static private int Difficulty ;
    
    
    void Start()
    {
        
        Difficulty = (PlayerPrefs.GetInt("DifficultyKey"));
        Ground.gameObject.transform.localScale += new Vector3(0, 0, Difficulty * 24 + 70);
        for (int i = 0; i < Difficulty; i++)
        {
            XOffset = Random.Range(-1 , 1);
            NumberOfBoxes = Random.Range(4, 6);
        for (int j = 0; j + 1 <= NumberOfBoxes; j++)
        {
            CurrentXValue = SpawnPoints[Random.Range(0, 7)];
                for (int k = 0; k <= 6; k++)
                { 
                    SpawnCheck();
                }
                PlacesSpawned[j] = CurrentXValue;
                PowerUpChance = Random.Range(1, 21);
                if (PowerUpChance == 20)
                {   
                    Instantiate(PowerUp, new Vector3(CurrentXValue + XOffset, 1, i * 12 + 20), Quaternion.identity);
                }
                else
                {
                    Instantiate(Obstacle, new Vector3(CurrentXValue + XOffset, 1, i * 12 + 20), Quaternion.identity);
                }
            
            PreviousX = CurrentXValue;
        }
    }
    }
    public void SpawnCheck()
    {
        for (int l = 0; l <= 6; l++)
        {

            while (CurrentXValue == PlacesSpawned[l])
            {
                CurrentXValue = SpawnPoints[Random.Range(0, 7)];
                SpawnCheck();
            }
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", .5f);
        }
       
    }
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void FixedUpdate()
    {
        if (Player.position.z > Difficulty * 12 + 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Difficulty = Difficulty + 5;
            PlayerPrefs.SetInt("DifficultyKey", Difficulty);
        }
    }
}

