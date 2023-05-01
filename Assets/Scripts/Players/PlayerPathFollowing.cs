using Obstacles.Disappearing;
using Paths;
using System.Collections.Generic;
using System.Threading;
using Towers.Disassembling;

namespace Players
{
    public class PlayerPathFollowing
    {
        private readonly PathFollowing _pathFollowing;
        private readonly Path _path;
        private readonly PlayerInputHandler _inputHandler;

        public PlayerPathFollowing(PathFollowing pathFollowing, Path path, PlayerInputHandler inputHandler)
        {
            _pathFollowing = pathFollowing;
            _path = path;
            _inputHandler = inputHandler;
        }
        public async void StartMovingAsync(CancellationToken cancellationToken)
        {
            IReadOnlyList<PathSegment> segments = _path.Segments;
            foreach (PathSegment pathSegment in segments)
            {
                _inputHandler.Enable();
                await _pathFollowing.MoveToNextAsync();

                if (cancellationToken.IsCancellationRequested)
                    return;

                (TowerDisassembling towerDisassembling, ObstaclesDisappearing obstaclesDisappearing)
                    = await pathSegment.PlatformBuilder.BuildAsync();

                _inputHandler.Disable();

                await towerDisassembling;
                await obstaclesDisappearing.ApplyAsync();
            }
        }
    }
}
