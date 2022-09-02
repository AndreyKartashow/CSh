using Roguelike.Core;
using Roguelike.Systems;

namespace Roguelike.Interfaces
{
    public interface IBehavior
    {
        bool Act(Monster monster, CommandSystem commandSystem);          
    }
}
