using UnityEngine;

public static class HelperFunctionsSTATIC
{
    
    // Start is called before the first frame update
    public static void SpawnAnim(Enemy enemy)
    {
        

       

            var dur = enemy.spawnParticleSystem.main.duration;
            var em = enemy.spawnParticleSystem.emission;
            //enemy.sparticleSystem.speed
            em.enabled = true;
            enemy.spawnParticleSystem.Play();

           
          
     
    }
    public static void DestroyAnim(Enemy enemy, bool destroyed)
    {
       
        if (!destroyed)
        {
        var dur = enemy.destroyParticleSystem.main.duration;
        var em = enemy.destroyParticleSystem.emission;

        em.enabled = true;
        enemy.destroyParticleSystem.Play();

        Object.Destroy(enemy.sr);
        enemy.Invoke(nameof(enemy.destroyTarget), dur);
        
        }
    }
}

