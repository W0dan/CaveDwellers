namespace CaveDwellers.Core.Shooting
{
    public interface ICanShootAProjectile
    {
        Projectile Shoot(double direction);
    }
}