using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameState; //Ã“Iƒƒ“ƒo

    void Awake()
    {
        //ƒQ[ƒ€‚Ì‰Šúó‘Ô‚ğPlaying‚Æİ’è
        gameState = "playing";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     // Update is called once per frame
    void Update()
    {
        Debug.Log(gameState);
    }
}
