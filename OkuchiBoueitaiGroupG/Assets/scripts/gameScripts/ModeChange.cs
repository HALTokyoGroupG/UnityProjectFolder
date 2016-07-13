using UnityEngine;
using System.Collections;


public class ModeChange : MonoBehaviour
{

	public enum VIEWMODE
	{
		UNKNOWN = 0,
		EXPLORE,
		CONVERSE,
		MENU,
		INVESTIGATE,
		BACK,
		CHECK,
		MAX
	};

	public GameObject MenuView;
	public GameObject ExploreUI;
	public GameObject ExplorationView;
	public GameObject InvestigateUI;
	public GameObject InvestigateView;
	public GameObject ConversationView;

	private int nCurMode = (int)VIEWMODE.EXPLORE;
	private int nNextMode = (int)VIEWMODE.EXPLORE;
	private int nLastMode = (int)VIEWMODE.EXPLORE;

	public float FadeRate = 0.1f;
	public SpriteRenderer Fader;
	private bool bFadeOut = false;
	private bool bFadeIn = false;
	private Color col = new Color(0f, 0f, 0f, 0f);

	//==============================
	// ゲームの初期化処理
	//==============================
	void Awake()
	{
		
	}

	//==============================
	// ゲームの更新処理
	//==============================
	void Update()
	{

		if (bFadeOut)
		{
			col.a += FadeRate;

			if (col.a > 1f)
			{
				bFadeOut = false;
				ChangeMode();
				bFadeIn = true;
			}
		}

		if (bFadeIn)
		{
			col.a -= FadeRate;

			if (col.a < 0f)
			{
				bFadeIn = false;
			}
		}

		Fader.color = col;

		//if (nCurMode != nNextMode)
		//{

		//}
	}

	//==============================
	// ゲームの更新処理
	//==============================
	void ChangeMode()
	{
		//Debug.Log("Next:" + nNextMode);
		//Debug.Log("Cur:" + nCurMode);
		//Debug.Log("Last:" + nLastMode);
		switch (nNextMode)
		{
			case (int)VIEWMODE.BACK:
				nNextMode = nLastMode;
				//nLastMode = nCurMode;
				ChangeMode();
				break;

			case (int)VIEWMODE.MENU:
				DeactivateAll();

				MenuView.SetActive(true);
				nLastMode = nCurMode;
				nCurMode = nNextMode;
				break;

			case (int)VIEWMODE.EXPLORE:
				DeactivateAll();

				ExploreUI.SetActive(true);
				ExplorationView.GetComponent<ExplorationView>().ActivateAll(true);
				nLastMode = nCurMode;
				nCurMode = nNextMode;
				break;

			case (int)VIEWMODE.INVESTIGATE:
				DeactivateAll();

				InvestigateView.SetActive(true);
				InvestigateUI.SetActive(true);
				nLastMode = nCurMode;
				nCurMode = nNextMode;
				break;

			case (int)VIEWMODE.CONVERSE:

				DeactivateAll();

				ExplorationView.GetComponent<ExplorationView>().ShowScenery(true);
				ConversationView.SetActive(true);
				nLastMode = nCurMode;
				nCurMode = nNextMode;
				break;

			case (int)VIEWMODE.CHECK:

				DeactivateAll();

				InvestigateView.SetActive(true);
				ConversationView.SetActive(true);
				nLastMode = nCurMode;
				nCurMode = nNextMode;
				break;
		}
	}

	//==============================
	// 
	//==============================
	public void DeactivateAll()
	{
		InvestigateView.SetActive(false);
		InvestigateUI.SetActive(false);

		ExploreUI.SetActive(false);
		ExplorationView.GetComponent<ExplorationView>().ActivateAll(false);
		ExplorationView.GetComponent<ExplorationView>().ShowProps(false);

		MenuView.SetActive(false);

		ConversationView.SetActive(false);
	}

	//==============================
	// モード切り替え処理
	//==============================
	public void ChangeTo(int nNo)
	{
		nNextMode = nNo;
		bFadeOut = true;
	}

	public void FastChange(int nNo)
	{
		nNextMode = nNo;
		ChangeMode();
		bFadeIn = true;
	}

}
