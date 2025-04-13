using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public GameEntity UnitEntity { get; private set; }
    [SerializeField] private BodyPartType _partType;
    public BodyPartType PartType => _partType;

    public void SetEntity(GameEntity entity) => UnitEntity = entity;
}

public enum BodyPartType
{
    Head,
    Body,
}