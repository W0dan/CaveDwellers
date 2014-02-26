namespace CaveDwellers.Core.Shooting
{
    public interface ICanBeHitByAProjectile
    {
        void Hit(Projectile projectile);
    }
}