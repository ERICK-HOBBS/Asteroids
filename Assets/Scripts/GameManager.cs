﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private GameState currentState;
	public StateGamePlaying stateGamePlaying{get;set;}
	public StateGameWon stateGameWon{get;set;}
	public StateGameLost stateGameLost{get;set;}
	
	private void Awake () 
	{
		stateGamePlaying = new StateGamePlaying(this);
		stateGameWon = new StateGameWon(this);
		stateGameLost = new StateGameLost(this);
	}
	
	private void Start () 
	{
		NewGameState( stateGamePlaying );
	}
	
	private void Update () 
	{
		if (currentState != null)
		{
			currentState.StateUpdate();
		}
	}
	
	private void OnGUI () 
	{
		if (currentState != null)
		{
			currentState.StateGUI();
		}
	}
	
	public void NewGameState(GameState newState)
	{
		if( null != currentState)
		{
			currentState.OnStateExit();
		}
		currentState = newState;
		currentState.OnStateEntered();
	}
}