internal class ShooterDeath: IState
{
    private EnemyShooterStates enemyShooterStates;

    public ShooterDeath(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }
    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        enemyShooterStates.enemyShooterAnimations.IsAlive = false;
    }
}