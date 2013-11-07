using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConsole
{
    public interface ISimulation
    {
        IDisplay Display { get; set; }

        int SpawnerCount { get; set; }

        void Init();

        void Start();

        void AddSpawner(ISpawner spawner);

        ISpawner GetSpawner(int i);

        void RemoveSpawner(ISpawner spawner);

        void ClearSpawners();

        ISpawner CreateRandomSpawner(IDisplay display);

        //void AddAnimator(IAnimator animator);

        void AddLivable(ILivable livable);

        void UpdateLivable(ILivable livable);

        void CheckAnimationQueue();

        int Difficulty { get; set; }

        void RemoveLivable(ILivable livable);
    }
}
