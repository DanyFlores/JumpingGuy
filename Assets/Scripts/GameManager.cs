using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamesState
{
    nemu,
    inTheGame,
    gameOver
}

public class GameManager : MonoBehaviour {

    public GamesState currentGameState = GamesState.nemu;

    void Start()
    {
        StartGame();
    }

	// se llama para inicar el juego o la partida
	public void StartGame () {
        ChangeGameState(GamesState.inTheGame);
	}
	
	// se llama cuando el jugador muere
    public void GameOver()
    {
        ChangeGameState(GamesState.gameOver);
    }

    //se llama cuando el jugador finaliza el juego y regresa al menu principal
    public void BackToMainMenu()
    {
        ChangeGameState(GamesState.nemu);
    }

    void ChangeGameState(GamesState newGamesState)
    {
        switch (newGamesState)
        {
            case GamesState.nemu:
                //la esene debera mostrar el menu principal
                break;
            case GamesState.inTheGame:
                //debe configurarse para mostrar el juego
                break;
            case GamesState.gameOver:
                //la esena debe mostar la pantalla de fin de partida   
                break;
            default:
                break;
        }
    }
}
