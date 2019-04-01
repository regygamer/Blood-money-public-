﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChallengeBuilder : MonoBehaviour
{
    [SerializeField]
    public ChallengeContainer[] challenges;
    public GameObject challengeHolder;
    public GameObject challengePrefab;
    public Color completionColour;

    // Start is called before the first frame update
    void Start()
    {
        UpdateChallenges();
    }

    void OnEnable()
    {
        ChallengeContainer.onComplete += UpdateChallenges;
    }

    void OnDisable()
    {
        ChallengeContainer.onComplete -= UpdateChallenges;
    }

    void UpdateChallenges()
    {
        ClearChallenges();
        foreach (ChallengeContainer c in challenges)
        {
            var challengeInstance = Instantiate(challengePrefab);
            Text ChallengeNameText = challengeInstance.GetComponent<Text>();
            string ChallengeName = c.challengeName;
            Text ChallengeDescriptionText = challengeInstance.transform.GetChild(0).GetComponent<Text>();

            if (c.ChallengeComplete)
            {
                ChallengeName += " (Complete)";
                ChallengeNameText.color = completionColour;
                ChallengeDescriptionText.color = completionColour;
            }

            ChallengeNameText.text = ChallengeName;
            ChallengeDescriptionText.text = ChallengeDescriptionBuilder(c);
            challengeInstance.transform.parent = challengeHolder.transform;
        }
    }


    void ClearChallenges()
    {
        foreach (Transform child in challengeHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }

    string ChallengeDescriptionBuilder(ChallengeContainer container)
    {
        string challengeDescription = "";

        if (container.challenge.type == ChallengeType.Kill)
        {
            if(container.challenge.parameters == ChallengeParameters.Amount)
            {
                if (container.challenge.specifier == ChallengeSpecifier.None)
                {
                    challengeDescription = "Kill " + container.challenge.challengeValue + " Enemies";
                }
            }
        }

        if (container.challenge.type == ChallengeType.Dodge)
        {
            if (container.challenge.parameters == ChallengeParameters.Amount)
            {              
                    challengeDescription = "Dodge " + container.challenge.challengeValue + " Times";
            }
        }

        return challengeDescription;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
