
using AiState;
using Godot;

/// <summary>
/// boss用于召唤小怪的投射物
/// </summary>
[Tool]
public partial class Summons : ActivityObject
{
    private ActivityObject _target;
    
    public void InitTarget(ActivityObject target)
    {
        _target = target;
    }
    
    protected override void OnFirstFallToGround()
    {
        var id = Utils.Random.RandomChoose(Ids.Id_enemy0001);
        var enemy = Create<Enemy>(id);
        var randomWeapon = World.RandomPool.GetRandomWeapon();
        enemy.PickUpWeapon(Create<Weapon>(randomWeapon));

        if (_target != null)
        {
            var stateBase = (AiAstonishedState)enemy.StateController.GetState(AIStateEnum.AiAstonished);
            stateBase.IsEntred = true;
            enemy.LookTarget = _target;
        }
        enemy.PutDown(Position, RoomLayerEnum.YSortLayer);
        
        //出生特效
        var effect = ObjectManager.GetPoolItem<IEffect>(ResourcePath.prefab_effect_common_Effect1_tscn);
        var node = (Node2D)effect;
        node.Position = Position + new Vector2(0, -5);
        node.AddToActivityRoot(RoomLayerEnum.YSortLayer);
        effect.PlayEffect();
        
        
        Destroy();
    }
}