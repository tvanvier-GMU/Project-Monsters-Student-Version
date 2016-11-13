using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
	public Monster playerMonster;
	public Monster opponentMonster;

	public bool playersTurn = true;

	[Header("Health Bars")]
	public Image playerHealthBar;
	public Image playerHealthBarBase;
	public Image opponentHealthBar;
	public Image opponentHealthBarBase;
	public float playerHealthBarMaxLength;
	public float opponentHealthBarMaxLength;
	public Text playerHealthText;
	public Text opponentHealthText;

	[Header("Name Labels")]
	public Text opponentMonsterText;
	public Text playerMonsterText;

	// Use this for initialization
	void Start () {
		opponentHealthBarMaxLength = opponentHealthBarBase.rectTransform.rect.width;
		playerHealthBarMaxLength = playerHealthBarBase.rectTransform.rect.width;

	}
	
	// Update is called once per frame
	void Update () {
		float percentHealth;
		//Opponent Display
		if (opponentMonster != null) {
			percentHealth = opponentMonster.currentHealth / (float)(opponentMonster.maxHealth);
			opponentHealthBar.rectTransform.sizeDelta = new Vector2 (opponentHealthBarMaxLength * percentHealth, opponentHealthBar.rectTransform.sizeDelta.y);
			opponentMonsterText.text = string.Format("{0} ({1})", opponentMonster.nickname, opponentMonster.speciesName);
			opponentHealthText.text = string.Format("HP: {0} / {1}", opponentMonster.currentHealth, opponentMonster.maxHealth);
		}
		if (playerMonster != null) {
			//Player health display
			percentHealth = playerMonster.currentHealth / (float)(playerMonster.maxHealth);
			playerHealthBar.rectTransform.sizeDelta = new Vector2 (playerHealthBarMaxLength * percentHealth, playerHealthBar.rectTransform.sizeDelta.y);
			playerMonsterText.text = string.Format("{0} ({1})", playerMonster.nickname, playerMonster.speciesName);
			playerHealthText.text = string.Format("HP: {0} / {1}", playerMonster.currentHealth, playerMonster.maxHealth);
		}
	}


	public Monster GetTarget(Monster attackingMonster, TargetingType targeting){
		//This is where a more complicated targeting system would go, for multi-battles.
		if (attackingMonster == playerMonster) {
			if (targeting == TargetingType.SingleEnemy || targeting == TargetingType.AllEnemies) {
				return opponentMonster;
			} else {
				return playerMonster;
			}
		} else {
			return null;
		}
	}

	//TODO: Create AI attacking methods
	//TODO: ACTUALLY apply buff effects when using a move.
	//TODO: Allow for multi-targeting and target selection

	public void UseBattleMove(int index, Monster targetMonster){
		
	}
}
