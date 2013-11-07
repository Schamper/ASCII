using ASCII;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConsole
{
    public interface IDisplay
    {
        void AnimateEntity(ILivable livable);

        void AddLivable(ILivable livable);

        void RemoveLivable(ILivable livable);

        void DrawEntity(ILivable livable);

        bool ReachedFort(int[] loc);

        void UpdateFort();

        void BuildFort(IFort fort);

        bool HasFort();

        bool isDone();

        int RequestDifficulty();

        void Initialize();

        void Gameover();

        void End();

    }
}
