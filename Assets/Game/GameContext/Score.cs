
using System;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour, IInitializable, IDisposable
{
    public event Action<int> ScoreChanged;
    public event Action<TypeReward, int> RewardChanged;
    
    private Bag _bag;
    private ValueRewards _valueRewards;
    
    private int _diamondScore;
    private int _emiralcore;
    private int _topasScore;
    
    [Space]
    [SerializeField] private int _scorePerSecond;

    private int _score;
    private float _timeSinceLastUpdate;
    
    [Inject]
    public void Construct(Entity entity, ValueRewards valueRewards)
    {
        _bag = entity.GetComponentImplementing<Bag>();
        _valueRewards = valueRewards;
    }
    
    public void Initialize()
    {
        _bag.RewardAdded += AddReward;
    }
    
    public void Dispose()
    {
        _bag.RewardAdded -= AddReward;
    }


    private void Update()
    {
        AddScore();
    }

    private void AddScore()
    {
        _timeSinceLastUpdate += Time.deltaTime;
        
        int pointsToAdd = Mathf.FloorToInt(_timeSinceLastUpdate * _scorePerSecond);
        
        _score += pointsToAdd;
        
        ScoreChanged.Invoke(_score);
        
        _timeSinceLastUpdate -= pointsToAdd / (float)_scorePerSecond;
    }

    private void AddReward(TypeReward type)
    {
        switch (type)
        {
            case TypeReward.DIAMOND:
                _diamondScore++;
               RewardChanged?.Invoke(TypeReward.DIAMOND,_diamondScore);
                break;
            case TypeReward.EMIRAL:
                _emiralcore++;
                RewardChanged?.Invoke(TypeReward.EMIRAL,_emiralcore);
                break;
            case TypeReward.TOPAS:
                _topasScore++;
                RewardChanged?.Invoke(TypeReward.TOPAS,_topasScore);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        Debug.Log(_valueRewards.Value);
        _score += _valueRewards.Value[type];
        ScoreChanged.Invoke(_score);
    }
}
