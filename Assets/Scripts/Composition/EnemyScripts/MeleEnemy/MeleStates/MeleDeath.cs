internal class MeleDeath : IState
{
    private EnemyMeleStates enemyMeleStates;

    public MeleDeath(EnemyMeleStates enemyMeleStates)
    {
        this.enemyMeleStates = enemyMeleStates;
    }

    public void OnEnter()
    {
      
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        enemyMeleStates.enemyMeleAnimations.IsAlive = false;
    }
}