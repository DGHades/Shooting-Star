using UnityEngine;

public static class HelperFunctionsSTATIC
{
    
    // Start is called before the first frame update
    public static void SpawnAnim(Enemy enemy)
    {
        

       

            var dur = enemy.sparticleSystem.main.duration;
            var em = enemy.sparticleSystem.emission;
            //enemy.sparticleSystem.speed
            em.enabled = true;
            enemy.sparticleSystem.Play();

           
          
     
    }
    public static void DestroyAnim(Enemy enemy, bool destroyed)
    {
       
        if (!destroyed)
        {

       
        GlobalVariable.score += 2;
        GlobalVariable.fillbarValue += 2;

        var dur = enemy.sparticleSystem.main.duration;
        var em = enemy.sparticleSystem.emission;

        em.enabled = true;
        enemy.sparticleSystem.Play();

        Object.Destroy(enemy.sr);
        enemy.Invoke(nameof(enemy.destroyTarget), dur);
        }
    }
}

