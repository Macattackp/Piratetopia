using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationTracker : MonoBehaviour {

    public int maxLovesHates = 3;
    public int maxLikesDislikes = 6;

    //******************POTENTIALLY TEMPORARY UNTIL NPC CREATION ESTABLISHED***************************

    //HashSets to avoid duplicates
    public HashSet<string> loveList = new HashSet<string>();
    public HashSet<string> hateList = new HashSet<string>();
    public HashSet<string> likeList = new HashSet<string>();
    public HashSet<string> dislikeList = new HashSet<string>();

    public int reputation = 0;
    public int loveHateModifier = 3;
    public int likeDislikeModifier = 1;
    

    //************************************************************************************************

    public List<Reputation> reputationList = new List<Reputation>();

	// Use this for initialization
	void Start () {
        ListDeclaration();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void reputationCheck(string call)
    {
        
        if (loveList.Contains(call))
        {
            reputation += loveHateModifier;
        }

        if (likeList.Contains(call))
        {
            reputation += likeDislikeModifier;
        }

        if (dislikeList.Contains(call))
        {
            reputation -= likeDislikeModifier;
        }

        if (hateList.Contains(call))
        {
            reputation -= loveHateModifier;
        }
    }

    void reputationAssignment()
    {
        int i = 0;
        int listSelection = 0;
        int coinToss = 0;
        string a;
        string b;
        while (i < maxLovesHates)
        {
            listSelection = Random.Range(0,reputationList.Count-1);
            coinToss = Random.Range(1, 2);

            if (coinToss == 1)
            {
                a = reputationList[listSelection].choiceA;
                b = reputationList[listSelection].choiceB;
            }
            else
            {
                a = reputationList[listSelection].choiceB;
                b = reputationList[listSelection].choiceA;
            }

            loveList.Add(a);
            hateList.Add(b);

            i++;
        }

        while (i < maxLikesDislikes)
        {
            listSelection = Random.Range(0, reputationList.Count - 1);
            coinToss = Random.Range(1, 2);

            if (coinToss == 1)
            {
                a = reputationList[listSelection].choiceA;
                b = reputationList[listSelection].choiceB;
            }
            else
            {
                a = reputationList[listSelection].choiceB;
                b = reputationList[listSelection].choiceA;
            }

            likeList.Add(a);
            dislikeList.Add(b);

            i++;
        }
    }

    void ListDeclaration()
    {
        ListAdd("Courage", "Cowardice");                //1
        ListAdd("Benevolance", "Greed");                //2
        ListAdd("Proactive", "Lazy");                   //3
        ListAdd("Navy", "Pirate");                      //4
        ListAdd("Treasure", "Upgrades");                //5
        ListAdd("Melee", "Range");                      //6
        ListAdd("Stealth", "Loud");                     //7
        ListAdd("Gourmet", "Cheap Food");               //8
        ListAdd("Allies", "Loner");                     //9
        ListAdd("Loyalty", "Free Spirit");              //10
        ListAdd("Good Sailing", "Good Fighting");       //11
        ListAdd("Vengeance", "Mercy");                  //12
        ListAdd("Monster Hunting", "Bounty Hunting");   //13
        ListAdd("Cheese", "Onions");                    //14
    }

    void ListAdd(string a, string b)
    {
        reputationList.Add(new Reputation
        {
            choiceA = a,
            choiceB = b
        });
    }
}
